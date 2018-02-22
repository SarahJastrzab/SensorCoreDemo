using SensorData.CassandraModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorData.ViewModels
{
    public class Status  
    {
        private Boolean isExpected;
        public Guid StatusCode { get; set; }
        public String Name { get; set; }
        public String Building { get; set; }
        public String Room { get; set; }
        public String Floor { get; set; }
        public String Make { get; set; }
        public String Model { get; set; }
        public Double ExpectedMin { get; set; }
        public Double ExpectedMax { get; set; }
        public DateTime ReadDate { get; set; }
        public Double ReadValue { get; set; }
        public List<SensorRead> Reads { get; set; }
        public String Units { get; set; }
        public Boolean IsExpected()
        {
            if(ReadValue <= ExpectedMax && ReadValue >= ExpectedMin)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void IsExpected(Boolean value)
        {
            isExpected = value;

        }
    }
}
