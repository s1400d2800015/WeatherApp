using System;
using WeatherApp.Application.Interfaces;

namespace WeatherApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICurrentWeatherService currentWeatherService { get; }
        public UnitOfWork(ICurrentWeatherService currentWeatherService)
        {
            this.currentWeatherService = currentWeatherService;

        }
    }
}
