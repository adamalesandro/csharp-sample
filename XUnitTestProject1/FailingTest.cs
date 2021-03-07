using ConsoleApp2;
using Xunit;

namespace XUnitTestProject1
{
    public class FailingTest
    {
        [Fact(DisplayName = "Oh no! This test will fail")]
        public void ThisTestWillFail()
        {
            var security = new Security { Ticker = "AAPL", PricingFactor = 1m };
            var trade = new Trade(security) { TradeDirection = Direction.SELL, Shares = 100m, Price = 1m, Commission = 1.11m };

            Assert.Equal(100m, trade.Shares);
            Assert.Equal(1m, trade.Price);
            Assert.Equal(98.89m, trade.Proceeds);
        }
    }
}
