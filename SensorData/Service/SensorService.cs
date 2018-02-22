using SensorData.CassandraModels;
using SensorData.Models;
using SensorData.Repositories;
using SensorData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorData.Service
{
    public class SensorService : ISensorService
    {
        ICassandraRepository _cassandraRepo;
        ISensorRepository _sensorRepo;

        public SensorService(ICassandraRepository cassandraRepo, ISensorRepository sensorRepo)
        {
            _cassandraRepo = cassandraRepo;
            _sensorRepo = sensorRepo;
        }
        public List<Status> GetCurrentStatus( DateTime startDate, DateTime endDate)
        {
           List<Sensor> sensors =  _sensorRepo.All().ToList();
            List<Status> results = new List<Status>();
            foreach(Sensor sensor in sensors)
            {
                List<SensorRead> reads = _cassandraRepo.GetAllReadsByDate(Guid.Parse(sensor.SensorCode), startDate, endDate);
                Status status = ReadsMappingExtension.ToViewModel(sensor.Location, sensor, sensor.SensorType, reads);
                results.Add(status);
            }
            return results;
        }

    }
}
