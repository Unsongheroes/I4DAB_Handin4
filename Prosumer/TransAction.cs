using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosumer
{
    class Transaction
    {
        public string TradeId { get; set; }
        public int AmountOfPowerBought { get; set; }
        public int BuyingPosumerId { get; set; }
        public int SellingPosumerId { get; set; }
        public bool Spent { get; set; }

    }
}
