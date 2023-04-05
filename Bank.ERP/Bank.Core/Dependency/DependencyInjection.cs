using Bank.Application.Behaviour;
using Bank.Core.Constant;
using Bank.Core.EventBus;
using Bank.Core.Interceptors;
using Bank.Domain.Interface;
using Bank.Infrastructure.Persistence;
using Bank.Infrastructure.Repository;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bank.Core.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration config)
        {
            var assembley = Assembly.GetExecutingAssembly();


            // Add Lifetime for  Thirdparty Intigration
            services.AddValidatorsFromAssembly(assembley);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembley)); 
            services.AddTransient<IEventBusProvider, EventBusProvider>();  
            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
                {
                    config.Host(new Uri(ERPConstant.RabbitMQ_URL), h =>
                    {
                        h.Username(ERPConstant.RabbitMQ_UserName);
                        h.Password(ERPConstant.RabbitMQ_Password);
                    });
                }));
            });


            // Add Lifetime for Behaviours
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));


            // Add Lifetime for Db Specific 
            services.AddSingleton<DomainEventToOutbox>();
            services.AddDbContext<BankDbContext>((serviceProvide, options) =>
            {
                var interceptors = serviceProvide.GetService<DomainEventToOutbox>();
                options.UseSqlServer(config.GetConnectionString("ConnectionString")).AddInterceptors(interceptors);
            });
             

            // Add Lifetime for Repository
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
