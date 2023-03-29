#region Using
using Bank.Application.Behaviour;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection; 
#endregion

namespace Bank.Application.Extention
{
    public static class MediatorRegistrationExtention
    {
        /// <summary>
        /// Mediator to add in pipline
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMediatorRegistrationGroup(
           this IServiceCollection services)
        {
            //// Resolve Behaviours
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
