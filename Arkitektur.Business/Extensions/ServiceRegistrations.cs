using Arkitektur.Business.Services.AboutServices;
using Arkitektur.Business.Services.AppointmentServices;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Arkitektur.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddBusinessExt(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutService> ();
            services.AddScoped<IAppointmentService, AppointmentService> ();






            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
