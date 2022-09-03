using Common.Global.Core;
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
            

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(CoreConstants.contactDBconnectionString);
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            });


            //configuration.GetConnectionString("ContactAppConnectionString")

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserInformationRepository, UserInformationRepository>();
            services.AddScoped<IUserReportRepository, UserReportRepository>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
