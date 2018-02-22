using SensorData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorData.Service
{
    public interface ISensorService
    {
        List<Status> GetCurrentStatus(DateTime startDate, DateTime endDate);

    }
}
