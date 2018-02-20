using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SensorData.Models
{
    [JsonObject(IsReference = true)]
    public class SensorType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ReadUnits { get; set; }

        public virtual List<Sensor> Sensors { get; set; }
    }
}
