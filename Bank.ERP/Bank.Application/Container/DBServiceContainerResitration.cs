#region Using
using Bank.Core.Context;
using Microsoft.EntityFrameworkCore;
#endregion

namespace Bank.Application.Container
{ 
    public static class DBServiceContainerResitration
    { 
        /// <summary>
        /// Static extention to register context
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddContextGroup(
             this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<BankDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("ConnectionString")));

            return services;
        } 

    }
}
