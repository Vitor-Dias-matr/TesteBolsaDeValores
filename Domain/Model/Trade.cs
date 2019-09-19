using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Trade
    {
        public string IdTrade { get; set; }
        public int NoOfShares { get; set; }
        public string Action { get; set; }
        public int Price { get; set; }
        public string Symbol { get; set; }
        public string IdPortfolio { get; set; }
    }
}
