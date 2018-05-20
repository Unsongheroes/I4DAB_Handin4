using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProsumerInfo.Models;

namespace ProsumerInfo.Data
{
    public class ProsumerInfoContext : DbContext
    {
        public ProsumerInfoContext (DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SmartMeter>().Property(s => s.GeneratedPower).HasField("_generatedPower")
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            modelBuilder.Entity<SmartMeter>().Property(s => s.UsedPower).HasField("_usedPower")
                .UsePropertyAccessMode(PropertyAccessMode.Field);

        }

        public DbSet<ProsumerInfo.Models.Prosumer> Prosumers { get; set; }
        public DbSet<ProsumerInfo.Models.SmartMeter> SmartMeters { get; set; }
    }
}
