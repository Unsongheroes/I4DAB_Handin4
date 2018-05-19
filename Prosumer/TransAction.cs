using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosumer
{
    class Transaction
    {
        public string TraderId { get; set; }
        public int AmountOfPower { get; set; }
        public int BuyingPosumerId { get; set; }
        public int BuyingFromPosumerId { get; set; }

    }
}
