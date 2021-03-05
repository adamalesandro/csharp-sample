using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class Trade
    {

        public Trade(Security security)
        {
            Security = security;
        }

        public Security Security { get;}

        public Direction? TradeDirection { get; set; }
        public string Ticker => Security.Ticker;
        public decimal Shares { get; set; }
        public decimal Price { get; set; }
        public decimal Commission { get; set; }

        public decimal Proceeds
        {
            get
            {
                if (TradeDirection == Direction.BUY)
                    return Shares * Price * Security.PricingFactor.Value + Commission;
                else if (TradeDirection == Direction.SELL)
                    return Shares * Price * Security.PricingFactor.Value - Commission;
                else
                    throw new ArgumentException("Trade Direction was not supplied");
            }
        }
    }

    public enum Direction
    {
        BUY,
        SELL
    }
}
