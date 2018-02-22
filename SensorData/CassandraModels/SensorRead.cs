using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorData.CassandraModels
{
    public class SensorRead
    {
        public Guid SensorCode { get; set; }
        public DateTime RecordDate { get; set; }
        public double ReadValue{ get; set; }

    }
}
