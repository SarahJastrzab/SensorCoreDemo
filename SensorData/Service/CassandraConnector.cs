using Cassandra;
using SensorData.CassandraModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorData.Service
{
    public static class CassandraConnector
    {
       
        public static ISession ConnectCassandra()
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("192.168.99.100").WithPort(9042).Build();
            return cluster.Connect("demo");
        }
      


    }
}
