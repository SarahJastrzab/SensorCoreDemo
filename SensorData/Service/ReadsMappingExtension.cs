using SensorData.CassandraModels;
using SensorData.Models;
using SensorData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorData.Service
{
    public static class ReadsMappingExtension
    {
        public static Status ToViewModel(Location location, Sensor sensor, SensorType type, List<SensorRead> reads)
        {
            Status status = new Status();
            status.Building = location.BuildingCode;
            status.Floor = location.FloorCode;
            status.Room = location.RoomCode;
            status.ExpectedMax = sensor.ExpectedMax;
            status.ExpectedMin = sensor.ExpectedMin;
            status.Name = sensor.Name;
            status.StatusCode = Guid.Parse(sensor.SensorCode);
            status.Make = type.Make;
            status.Model = type.Model;
            status.Units = type.ReadUnits;
            status.Reads = reads;
            if(reads.FirstOrDefault() != null)
            {
                status.ReadDate = reads.FirstOrDefault().RecordDate;
                status.ReadValue = reads.FirstOrDefault().ReadValue;
            }
            return status;
        }
    }
}
