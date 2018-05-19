using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosumer
{
    public class Prosumer
    {
        //primary key
        public int ProsumerId { get; }
        public string Name { get; set; }
        //"Virksomhed" el. "Person"
        public string Type { get; set; }
        public SmartMeter SmartMeter { get; set; }
    }
}
