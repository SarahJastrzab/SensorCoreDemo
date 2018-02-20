using SensorData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorData.Repositories
{
    public interface ISensorRepository
    {
        bool SensorExists(string id);
        IEnumerable<Sensor> All();
        Sensor Find(string id);
        void Insert(Sensor item);
        void Update(Sensor item);
        void Delete(string id);
    }
}
