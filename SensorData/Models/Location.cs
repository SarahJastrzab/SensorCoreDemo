using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SensorData.Models
{
    [JsonObject(IsReference = true)]
    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string RoomCode { get; set; }
        public string BuildingCode { get; set; }    
        public string FloorCode { get; set; }

        public virtual List<Sensor> Sensors { get; set; }
    }
}
