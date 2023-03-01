#region MyRegion
using Bank.Core.Interface;
using Bank.Core.Repository; 
#endregion

namespace Bank.Application.ServiceContainer
{
    public static class ServiceContainerRegistarationExtention
    {
        /// <summary>
        /// Extention to resolve dependancy of repository
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositoryGroup(
          this IServiceCollection services)
        {
            // Resolve Validation
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerBankRepository, CustomerBankRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>(); 
            return services;
        }

    }
}
