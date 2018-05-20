using System.Collections.Generic;
using Newtonsoft.Json;

namespace SmartgridInfo.Models
{
    public class SmartGrid
    {
        public string SmartGridId { get; set; }
        public int TotalGeneratedPower { get; set; }
        public int TotalUsedPower { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}