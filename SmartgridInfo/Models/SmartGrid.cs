using System.Collections.Generic;

namespace SmartgridInfo.Models
{
    public class SmartGrid
    {
        public string SmartGridId { get; set; }
        public int TotalGeneratedPower { get; set; }
        public int TotalUsedPower { get; set; }
    }
}