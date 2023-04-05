#region Using
using Bank.Core.EventBus;
using Bank.Core.ViewModel;
using Bank.Domain.Shared;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
#endregion

namespace Bank.Infrastructure.Persistence.Interceptors
{
    public sealed class DomainEventToOutbox : SaveChangesInterceptor
    {

        private readonly IEventBusProvider _IEventBusProvider;

        public DomainEventToOutbox(IEventBusProvider IEventBusProvider)
        {
            _IEventBusProvider = IEventBusProvider;
        }
        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            var persistContext = eventData.Context;
            if (persistContext == null)
            {
                return base.SavedChangesAsync(eventData, result, cancellationToken);
            }
            else
            {
                var OutBoxs = persistContext.ChangeTracker.Entries<AggregateRoot>()
                                            .Select(x => x.Entity)
                                            .SelectMany(x =>
                                            {
                                                var domainevents = x.GetDomainEvents();
                                                x.ClearEvent();
                                                return domainevents;
                                            })
                                            .Select(x => new DomainEventMetaData
                                            {
                                                ModuleId = Guid.NewGuid(),
                                                OccuranceOnDate = DateTime.UtcNow,
                                                TypeOfEvent = x.GetType().Name,
                                                Content = JsonConvert.SerializeObject(x, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })
                                            })
                                            .ToList();

                
                DomainEvents objDomainEvents = new();
                objDomainEvents.DomainEventMetaData = OutBoxs;
                _IEventBusProvider.publishEvent(objDomainEvents);
                return base.SavedChangesAsync(eventData, result, cancellationToken);
            }
        } 
    }
}
