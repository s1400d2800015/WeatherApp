using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WeatherApp.Application.Interfaces;
using WeatherApp.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WeatherApp.Infrastructure.Services
{
    public class CurrentWeatherService : ICurrentWeatherService
    {
        private readonly IConfiguration _configuration;
        private string _endpointURI;
        private string _apiKey;

        public CurrentWeatherService(IConfiguration configuration)
        {
            _configuration = configuration;
            _endpointURI = _configuration.GetSection("EndpointURI").Value;
            _apiKey = _configuration.GetSection("WeatherAPIKey").Value;
        }

        public async Task<CurrentWeatherModel> GetCurrentWeatherAsync()
        {
            try
            {
                string latitude = _configuration.GetSection("latitude").Value; ;
                string longitude = _configuration.GetSection("longitude").Value; ;

                string apiUrl = $"{_endpointURI }data/2.5/weather?lat={latitude}&lon={longitude}&appid={_apiKey}";

                using (var client = new HttpClient())
                {
                    
                    var getData = client.GetAsync(apiUrl);

                    getData.Wait();

                    var result = getData.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var data = await result.Content.ReadAsStringAsync();

                        var returnData = Newtonsoft.Json.JsonConvert.DeserializeObject<CurrentWeatherModel>(data);

                        return returnData;
                    }
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<CurrentWeatherModel> GetCurrentWeatherAsync(string latitude, string longitude)
        {
            try
            {
               
                string apiUrl = $"{_endpointURI }data/2.5/weather?lat={latitude}&lon={longitude}&appid={_apiKey}";

                using (var client = new HttpClient())
                {

                    var getData = client.GetAsync(apiUrl);

                    getData.Wait();

                    var result = getData.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var data = await result.Content.ReadAsStringAsync();

                        var returnData = Newtonsoft.Json.JsonConvert.DeserializeObject<CurrentWeatherModel>(data);

                        return returnData;
                    }
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<CurrentWeatherModel> GetCurrentWeatherAsync(string cityName)
        {
            try
            {

                string apiUrl = $"{_endpointURI }data/2.5/weather?q={cityName}&appid={_apiKey}";

                using (var client = new HttpClient())
                {

                    var getData = client.GetAsync(apiUrl);

                    getData.Wait();

                    var result = getData.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var data = await result.Content.ReadAsStringAsync();

                        var returnData = Newtonsoft.Json.JsonConvert.DeserializeObject<CurrentWeatherModel>(data);

                        return returnData;
                    }
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }



    }
}
