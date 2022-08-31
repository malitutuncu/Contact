using Common.Global.DataService;
using Contact.Data.Context;
using Contact.Data.Core;
using Contact.Data.Repositories;
using Contact.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data
{
    public static class DataServiceRegistration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            const string connectionString = "Server=127.0.0.1;Port=5433;Database=ContactDB;User Id=postgres;Password=123456;";

            services.AddDbContext<AppDbContext>(options =>
                                                     options.UseNpgsql(connectionString));
            //configuration.GetConnectionString("ContactAppConnectionString")

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserInformationRepository, UserInformationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
