#region Using
using Bank.Application.Behaviour;
using FluentValidation;
using MediatR;

#endregion
namespace Bank.Application.Extention
{
    public static class ValidatorDependancyRegistrationExtention
    {
        /// <summary>
        /// AddValidatorGroup Extention to add this in pipline 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddValidatorGroup(
           this IServiceCollection services)
        {
            // Resolve Validation
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            return services;
        }
    }
}
