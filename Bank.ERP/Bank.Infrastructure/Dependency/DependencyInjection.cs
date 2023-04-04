﻿#region MyRegion 
using Bank.Core.Interface;
using Bank.Domain.Interface;
using Bank.Infrastructure.Persistence;
using Bank.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
#endregion

namespace Bank.Infrastructure.ServiceContainer
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extention to resolve dependancy of repository
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(
          this IServiceCollection services, IConfiguration config)
        {
            // Add Connection string
            services.AddDbContext<BankDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("ConnectionString")));

            // Resolve Dependancy
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IBankRepository, BankRepository>();
            services.AddTransient<IBranchRepository, BranchRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerBankRepository, CustomerBankRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>(); 
            return services;
        }

    }
}
