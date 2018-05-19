using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosumer
{
    public class SmartGrid
    {
        public int SmartGridId { get; set; }
        public string Name { get; set; }
        public int PowerBalance { get; set; }
        public List<Prosumer> prosumers { get; set; }

    }
}
