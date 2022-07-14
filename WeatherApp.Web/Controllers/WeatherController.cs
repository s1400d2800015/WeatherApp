using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IConfiguration _configuration;
        public WeatherController(ILogger<WeatherController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this._configuration = configuration;
        }

        [Route("get")]
        public async Task<IActionResult> FetchHeidenheimWeatherDataAsync()
        {
            try
            {
              
                string apiUrl = _configuration.GetSection("WeatherApiEndpoint").Value;

                using (var client = new HttpClient())
                {

                    var getData = client.GetAsync(apiUrl);

                    getData.Wait();

                    var result = getData.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var data = await result.Content.ReadAsStringAsync();

                        var returnData = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherAppDataModel>(data);

                        return Ok(returnData);
                    }
                }

                return null;
            }
            catch (Exception ex)
            {

                return null;
            }

        }
    }
}
