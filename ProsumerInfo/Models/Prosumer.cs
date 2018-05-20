using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProsumerInfo.Models
{
    public class Prosumer
    {
        //primary key
        public int Id { get; set; }
        //bit coin key
        public string PublicKey { get; private set; }
        //"Virksomhed" el. "Person"
        public string Type { get; private set; }
      
        public SmartMeter SmartMeter { get; private set; }

        public Prosumer(string publicKey, string type, SmartMeter smartMeter)
        {
            PublicKey = publicKey ?? throw new ArgumentNullException(nameof(publicKey));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            SmartMeter = smartMeter ?? throw new ArgumentNullException(nameof(smartMeter));
        }

        [JsonConstructor]
        private Prosumer()
        { }
    }
}
