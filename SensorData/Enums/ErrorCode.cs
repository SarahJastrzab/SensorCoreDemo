using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorData.Enums
{
    public enum ErrorCode
    {
        CouldNotUpdateSensor,
        CouldNotCreateSensor,
        CouldNotDeleteSensor,
        SensorNotFound,
        SensorAlreadyExists
    }
}
