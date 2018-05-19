using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsumerInfo.Models
{
    public class Prosumer
    {
        //primary key
        public int Id { get; set; }
        //bit coin key
        public string PublicKey { get; set; }
        //"Virksomhed" el. "Person"
        public string Type { get; set; }
        public SmartMeter SmartMeter { get; set; }
    }
}
