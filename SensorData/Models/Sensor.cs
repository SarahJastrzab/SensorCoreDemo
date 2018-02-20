using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SensorData.Models
{
    [JsonObject(IsReference = true)]
    public class Sensor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int SensorTypeId { get; set; }
        public string SensorCode { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public double ExpectedMin { get; set; }
        public double ExpectedMax { get; set; }

        public virtual SensorType SensorType { get; set; }
        public virtual Location Location {get; set;}

    }
}
