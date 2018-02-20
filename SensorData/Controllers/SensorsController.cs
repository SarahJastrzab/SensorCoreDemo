using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SensorData.DBContext;
using SensorData.Enums;
using SensorData.Models;
using SensorData.Repositories;

namespace SensorData.Controllers
{
    [Route("api/[controller]")]
    public class SensorsController : Controller
    {
        private readonly ISensorRepository _sensorRepo;
        
        public SensorsController(ISensorRepository sensorRepo)
        {
            _sensorRepo = sensorRepo;
        }

        // GET: Sensors
        [HttpGet]
        public IActionResult List()
        {
            return Ok(_sensorRepo.All());
        }

        // GET: Sensors/Details/5
      /*  public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensor = await _context.Sensors
                .Include(s => s.Location)
                .Include(s => s.SensorType)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sensor == null)
            {
                return NotFound();
            }

            return View(sensor);
        }*/

        // GET: Sensors/Create
        [HttpPost]
        public IActionResult Create([FromBody] Sensor sensor)
        {
           if(sensor != null && ModelState.IsValid)
            {
                if (_sensorRepo.SensorExists(sensor.SensorCode))
                {
                    Console.WriteLine(sensor.SensorCode);
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.SensorAlreadyExists.ToString());

                }
                else
                {
                    _sensorRepo.Insert(sensor);
                    return Ok(sensor);
                }

            }
            else
            {
                return BadRequest(ErrorCode.CouldNotCreateSensor.ToString());
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Sensor sensor)
        {
            if (sensor != null && ModelState.IsValid)
            {
                if (_sensorRepo.SensorExists(sensor.SensorCode))
                {
                    _sensorRepo.Update(sensor);
                    return Ok();
                }
                else
                {
                    return NotFound(ErrorCode.SensorNotFound.ToString());
                }
            }
            else
            {
                return BadRequest(ErrorCode.CouldNotUpdateSensor.ToString());
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (_sensorRepo.SensorExists(id))
            {
                _sensorRepo.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound(ErrorCode.SensorNotFound.ToString());
            }

        }

    
    }
}
