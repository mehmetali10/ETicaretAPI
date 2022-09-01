using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Persistence.Contexts;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Repositories;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection services)
        {
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString), ServiceLifetime.Singleton);
            services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>(); //interface isteği geldiği zaman concreteni döndür
            services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            services.AddSingleton<IProductReadRepository, ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
