using Microsoft.AspNetCore.Mvc;
using SensorData.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorData.Controllers
{
    [Route("api/[controller]")]
    public class ReadsController : Controller
    {
        private readonly ISensorService _sensorService;

            public ReadsController(ISensorService sensorService)
            {
                _sensorService = sensorService;
            }


        [HttpGet()]
        public IActionResult List([FromQuery(Name = "code")] Guid code, [FromQuery(Name = "startDate")] DateTime startDate, [FromQuery(Name = "endDate")] DateTime endDate )
        {
            return Ok(_sensorService.GetCurrentStatus(startDate, endDate));
        }
    }
}
