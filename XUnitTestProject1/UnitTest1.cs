using ConsoleApp2;
using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact(DisplayName = "Ticker has expected value")]
        public void TickerHasExpectedValue()
        {
            var security = new Security { Ticker = "TSLA" };
            var trade = new Trade(security);

            Assert.NotNull(trade.Security);
            Assert.Equal("TSLA", trade.Ticker);
        }

        [Fact(DisplayName = "Buy Proceeds has expected value")]
        public void BuyProceedsHasExpectedValue()
        {
            var security = new Security { Ticker = "AAPL", PricingFactor = 1m};

            var trade = new Trade(security) { TradeDirection = Direction.BUY, Shares = 10000m, Price = 20m,  Commission = 9.99m};

            Assert.Equal(200009.99m, trade.Proceeds);
        }

        [Fact(DisplayName = "Cover Proceeds has expected value")]
        public void CoverProceedsHasExpectedValue()
        {
            var security = new Security { Ticker = "GME", PricingFactor = 2m };

            var trade = new Trade(security) { TradeDirection = Direction.COVER, Shares = 100m, Price = 20m, Commission = 7.50m };

            Assert.Equal(4007.5m, trade.Proceeds);
        }

        [Fact(DisplayName = "Sell Proceeds has expected value")]
        public void SellProceedsHasExpectedValue()
        {
            var security = new Security { Ticker = "AAPL", PricingFactor = 1m };

            var trade = new Trade(security) { TradeDirection = Direction.SELL, Shares = 10000m, Price = 20m, Commission = 9.99m };

            Assert.Equal(199990.01m, trade.Proceeds);
        }

        [Fact(DisplayName = "Short Proceeds has expected value")]
        public void ShortProceedsHasExpectedValue()
        {
            var security = new Security { Ticker = "GME", PricingFactor = 2m };

            var trade = new Trade(security) { TradeDirection = Direction.SHORT, Shares = 100m, Price = 20m, Commission = 7.50m };

            Assert.Equal(3992.5m, trade.Proceeds);
        }

        [Fact(DisplayName = "Sum of all trades is correct")]
        public void SumOfAllTradesIsCorrect()
        {
            var aapl = new Security { Ticker = "AAPL", PricingFactor = 1m };
            var goog = new Security { Ticker = "GOOG", PricingFactor = 1m };
            var tsla = new Security { Ticker = "TSLA", PricingFactor = 1m };
            var gme = new Security { Ticker = "GME", PricingFactor = 1m };
            var f = new Security { Ticker = "F", PricingFactor = 1m };


            var trades = new[]
            {
                new Trade(aapl){ TradeDirection = Direction.BUY, Shares = 10000m, Price = 20m,  Commission = 9.99m},
                new Trade(goog){ TradeDirection = Direction.SELL, Shares = 10000m, Price = 20m,  Commission = 9.99m},
                new Trade(tsla){ TradeDirection = Direction.SELL, Shares = 10000m, Price = 20m,  Commission = 9.99m},
                new Trade(gme){ TradeDirection = Direction.BUY, Shares = 10000m, Price = 20m,  Commission = 9.99m},
                new Trade(f){ TradeDirection = Direction.SELL, Shares = 10000m, Price = 20m,  Commission = 9.99m},
            };

            Assert.Equal(999990.01m, trades.Sum(x => x.Proceeds));
        }

        [Fact(DisplayName = "Invalid Trade Direction throws exception")]
        public void InvalidTradeDirectionThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Trade(new Security()).Proceeds);
        }

        [Fact(DisplayName = "Trade Direction has expected values")]
        public void TradeDirectionHasExpectedValues()
        {
            var expected = new[] { "BUY", "SELL", "COVER", "SHORT" };
            var values = Enum.GetValues(typeof(Direction));

            foreach (var value in values)
                Assert.Contains(expected, x => x == value.ToString());
        }
    }
}
