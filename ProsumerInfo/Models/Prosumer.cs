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
        public enum ProsumerType
        {
            Private,
            Company
        }

        //primary key
        public int Id { get; set; }
        //bit coin key
        public string PublicKey { get; private set; }
        //"Virksomhed" el. "Person"
        public string Type { get; private set; }
      
        public SmartMeter SmartMeter { get; private set; }

        public Prosumer(string publicKey, ProsumerType type, SmartMeter smartMeter)
        {
            SmartMeter = smartMeter ?? throw new ArgumentNullException(nameof(smartMeter));
            SetPublicKey(publicKey);
            SetType(type);
        }

        public void SetType(ProsumerType type)
        {
            Type = type == ProsumerType.Private ? "Private" : "Company";
        }

        public void SetPublicKey(string publicKey)
        {
            PublicKey = publicKey ?? throw new ArgumentNullException(nameof(publicKey));
        }

        private Prosumer()
        { }
    }
}
