using Contact.Data.Context;
using Contact.Data.Repositories.Interfaces;
using Contact.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Contact.Business.Interfaces;
using Contact.Business.Services.UserServices;
using Contact.Business.Services.UserInformationServices;

namespace Contact.Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserInformationService, UserInformationService>();

            return services;
        }
    }
}

