#region Using
using Bank.Application.Behaviour;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

#endregion
namespace Bank.Application.Extention
{
    public static class BehaviourDependancyRegistrationExtention
    {
        /// <summary>
        /// Extention to Addpiplinebehaviour in pipline
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBehaviourDependencyGroup(
            this IServiceCollection services)
        {
            // Resolve Behaviours
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

            return services;
        }
    }
}
