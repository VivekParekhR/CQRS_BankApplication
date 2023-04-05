#region Using
using Bank.Domain.Entity;
using Bank.Domain.Shared;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using static MassTransit.ValidationResultExtensions;
#endregion

namespace Bank.Infrastructure.Persistence.Interceptors
{
    public sealed class DomainEventToOutbox : SaveChangesInterceptor
    {
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
                                            .Select(x => new OutBox
                                            {
                                                ModuleId = Guid.NewGuid(),
                                                OccuranceOnDate = DateTime.UtcNow,
                                                TypeOfEvent = x.GetType().Name,
                                                Content = JsonConvert.SerializeObject(x, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })
                                            })
                                            .ToList();

                //Todo insert into Mongodb as event soursing / we can use rabbitmq to send events persistContext.Set<OutBox>().AddRange(OutBoxs);
                return base.SavedChangesAsync(eventData, result, cancellationToken);

            }
        } 
    }
}
