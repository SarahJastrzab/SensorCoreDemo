using SensorData.CassandraModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorData.Service
{
     public interface ICassandraRepository
    {
         List<SensorRead> GetAllReadsByDate(Guid code, DateTime startDate, DateTime endDate);
    }
}
