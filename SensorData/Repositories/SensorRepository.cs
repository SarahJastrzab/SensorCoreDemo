using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SensorData.DBContext;
using SensorData.Models;

namespace SensorData.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly SensorContext _context;

        public SensorRepository(SensorContext context)
        {
            _context = context;
        }

        public IEnumerable<Sensor> All()
        {
            var sensorContext = _context.Sensors.Include(s => s.Location).Include(s => s.SensorType);
            return sensorContext.ToList();
        }

        public void Delete(String id)
        {

            Sensor sensor = GetId(id);

            if(sensor != null)
            {
                _context.Remove(sensor);
                _context.SaveChanges();
            }
        }

        public bool SensorExists(String id)
        {
           Sensor sensor = GetId(id);
            if(sensor != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public Sensor Find(String id)
        {
            Sensor sensor = GetId(id);
            if(sensor != null)
            {
                return sensor;
            }
            else { return null; }
        }

        public void Insert(Sensor sensor)
        {
            _context.Add(sensor);
            _context.SaveChanges();
        }

        public void Update(Sensor sensor)
        {
            try
            {
                if (SensorExists(sensor.SensorCode))
                {
                    _context.Update(sensor);
                    _context.SaveChanges();
                }

            }
            catch (DbUpdateConcurrencyException)
            {
              
              
            }
        }

        private Sensor GetId(String id)
        {
            var sensor = _context.Sensors
           .Include(s => s.Location)
           .Include(s => s.SensorType)
           .SingleOrDefaultAsync(m => m.SensorCode == id);
            if(sensor != null)
            {

                return sensor.Result;
            }
            return null;
        }
    }
}
