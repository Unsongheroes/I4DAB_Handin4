using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProsumerInfo.Models
{
    public class ProsumerInfoContext : DbContext
    {
        public ProsumerInfoContext (DbContextOptions<ProsumerInfoContext> options)
            : base(options)
        {
        }

        public DbSet<ProsumerInfo.Models.Prosumer> Prosumers { get; set; }
        public DbSet<ProsumerInfo.Models.SmartMeter> SmartMeters { get; set; }
    }
}
