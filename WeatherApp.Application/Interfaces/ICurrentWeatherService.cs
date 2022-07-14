using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Application.Interfaces
{
    public interface ICurrentWeatherService
    {
         Task<CurrentWeatherModel> GetCurrentWeatherAsync();
        Task<CurrentWeatherModel> GetCurrentWeatherAsync(string latitude, string longitude);
        Task<CurrentWeatherModel> GetCurrentWeatherAsync(string cityName);
    }
}
