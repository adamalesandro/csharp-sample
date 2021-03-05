using ConsoleApp2;
using Xunit;

namespace XUnitTestProject1
{
    public class FailingTest
    {
        [Fact(DisplayName = "Oh no! This test will fail")]
        public void ThisTestWillFail()
        {
            var security = new Security { Ticker = "AAPL" };
            var trade = new Trade(security) { Shares = 100m, Price = 1m };

            Assert.Equal(100m, trade.Shares);
            Assert.Equal(1m, trade.Price);
            Assert.Equal(100m, trade.Proceeds);
        }
    }
}
