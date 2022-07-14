using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Application.Interfaces;

namespace WeatherApp.WebApi.Controllers
{
    public class CurrentWeatherController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public CurrentWeatherController(ILogger<BaseController> logger, IUnitOfWork unitOfWork) : base(logger)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("get")]
        public IActionResult GetStaticWeatherUpdates()
        {
            try
            {
               var returnData = _unitOfWork.currentWeatherService.GetCurrentWeatherAsync();

                return Ok(returnData);

            }
            catch (Exception ex)
            {

              return  BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("getByLatandLong")]
        public IActionResult GetByLatandLong(string latitude, string longitude)
        {
            try
            {
                var returnData = _unitOfWork.currentWeatherService.GetCurrentWeatherAsync(latitude, longitude);

                return Ok(returnData);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        
        [HttpGet]
        [Route("getByCity")]
        public IActionResult GetByCityName(string city)
        {
            try
            {
                var returnData = _unitOfWork.currentWeatherService.GetCurrentWeatherAsync(city);

                return Ok(returnData);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}
