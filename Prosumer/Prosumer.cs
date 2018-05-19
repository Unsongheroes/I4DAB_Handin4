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
        public string ProsumerId { get; }
        //bit coin key
        public string PublicKey { get; set; }
        //"Virksomhed" el. "Person"
        public string Type { get; set; }
        public SmartMeter SmartMeter { get; set; }
    }
}
