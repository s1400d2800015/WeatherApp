using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WeatherApp.Application.Interfaces;
using WeatherApp.Infrastructure.Services;

namespace WeatherApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICurrentWeatherService, CurrentWeatherService>();

        }

    }
}
