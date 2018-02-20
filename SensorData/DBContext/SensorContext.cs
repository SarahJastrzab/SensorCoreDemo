using Microsoft.EntityFrameworkCore;
using SensorData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorData.DBContext
{
    public class SensorContext : DbContext
    {

        public SensorContext(DbContextOptions<SensorContext> options)
            : base(options)
        {

        }

        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorType> SensorTypes { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sensor>().ToTable("Sensors");
            modelBuilder.Entity<SensorType>().ToTable("SensorTypes");
            modelBuilder.Entity<Location>().ToTable("Locations");
        }
    }


}
