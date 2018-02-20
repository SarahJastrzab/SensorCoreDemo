using SensorData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorData.DBContext
{
    public static class DbInitialize
    {
        public static void Initialize(SensorContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Sensors.Any())
            {
                return;   // DB has been seeded
            }

            var sensorTypes = new SensorType[]
             {
                new SensorType{Make="Sony",Model="LR54",ReadUnits="Voltage"},
                new SensorType{Make="Arduino",Model="P90X",ReadUnits="Voltage"}
             };
            foreach (SensorType s in sensorTypes)
            {
                context.SensorTypes.Add(s);
            }
            context.SaveChanges();

            var locations = new Location[]
              {
                    new Location{RoomCode="CONF-A",BuildingCode="111",FloorCode="1"},
                    new Location{RoomCode="CAFE",BuildingCode="111",FloorCode="2"},
                    new Location{RoomCode="LAB-A",BuildingCode="222",FloorCode="2"},
                    new Location{RoomCode="LAB-B",BuildingCode="333",FloorCode="B"},


              };
            foreach (Location l in locations)
            {
                context.Locations.Add(l);
            }
            context.SaveChanges();


            var sensors = new Sensor[]
            {
            new Sensor{SensorTypeId=1,SensorCode="8b72630e-8fe2-4ac1-92fd-7528bf83bb4e",Name="A1",LocationId=1,ExpectedMin=1.0,ExpectedMax=2.0},
            new Sensor{SensorTypeId=1,SensorCode="3e6c0907-744e-4949-90ee-3333d15d7fa6",Name="A2",LocationId=1,ExpectedMin=1.1,ExpectedMax=2.0},
            new Sensor{SensorTypeId=2,SensorCode="edb3cfe7-8e3d-4afe-be92-181031e7e2f6", Name="B1",LocationId=1,ExpectedMin=48,ExpectedMax=50},
            new Sensor{SensorTypeId=1,SensorCode="17063805-1389-421e-9a56-ae520cf4449a", Name="B2",LocationId=2,ExpectedMin=0.0,ExpectedMax=50},
            new Sensor{SensorTypeId=2,SensorCode="648c640a-e89e-449b-9b45-ad4687e885bd",Name="C3",LocationId=3,ExpectedMin=0.0,ExpectedMax=50},
            new Sensor{SensorTypeId=1,SensorCode="c96b3ea3-35a5-4d21-9dff-ad347ba865c8",Name="C4",LocationId=4,ExpectedMin=0.0,ExpectedMax=50}
            };
            foreach (Sensor s in sensors)
            {
                context.Sensors.Add(s);
            }
            context.SaveChanges();

        }

    }
}
