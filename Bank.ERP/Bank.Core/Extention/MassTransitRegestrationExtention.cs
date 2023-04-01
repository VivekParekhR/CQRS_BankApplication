﻿
using Bank.Core.Constant;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bank.Core.Extention
{
    public static class MassTransitRegestrationExtention
    {

        public static IServiceCollection AddMassTransitGroup(
          this IServiceCollection services)
        {
            //// Resolve Behaviours
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

            return services;
        }

    }
}
