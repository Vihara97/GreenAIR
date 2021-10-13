using GreenAIR.REPOSITORY.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenAIR.REPOSITORY
{
    public class DataContext : DbContext
    {
        public DataContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-LSEHMN6;Database=GreenAIR_DB;Trusted_Connection=True;");
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<MonitoringCenter> MonitoringCenters { get; set; }
        public virtual DbSet<IOTDevice> IOTDevices { get; set; }
        public virtual DbSet<AirContentRecord> AirContentRecords { get; set; }
        public virtual DbSet<Vegitation> Vegitations { get; set; }
    }
}
