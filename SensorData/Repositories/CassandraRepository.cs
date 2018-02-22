using Cassandra;
using SensorData.CassandraModels;
using SensorData.DBContext;
using SensorData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorData.Service
{
    public class CassandraRepository : ICassandraRepository
    {
        ISession _session;
        public CassandraRepository()
        {
            _session = CassandraConnector.ConnectCassandra();
        }

        public List<SensorRead> GetAllReadsByDate(Guid code, DateTime startDate, DateTime endDate)
        {
            var query = new SimpleStatement("SELECT record_time, read_value, sensor_code FROM sensor_reads where sensor_code = ? AND record_time >= ? and record_time <= ?", code, startDate, endDate);
            var rs = _session.ExecuteAsync(query);
            List<SensorRead> results = new List<SensorRead>();
            foreach(Row row in rs.Result)
            {
               SensorRead read = MapResult(_session, row);
                results.Add(read);
            }
            return results;
        }

        private SensorRead MapResult(ISession session, Row row)
        {
            /*session.UserDefinedTypes.Define(
                  UdtMap.For<SensorRead>()
                    .Map(a => a.RecordDate, "record_time")
                    .Map(a => a.ReadValue, "read_value")
                    .Map(a => a.SensorCode, "sensor_code")
            );*/
            if (row != null)
            {
                SensorRead read = new SensorRead
                {
                    ReadValue = Double.Parse(row["read_value"].ToString()),
                    RecordDate = DateTime.Parse(row["record_time"].ToString()),
                    SensorCode = Guid.Parse(row["sensor_code"].ToString()),
                };

                return read;
                 
            }
            return null;
        }
    }
}
