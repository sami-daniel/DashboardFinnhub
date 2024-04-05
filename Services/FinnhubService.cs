using ServicesAbstractions;

namespace Services
{
    public class FinnhubService : IFinnhubService
    {
        public Dictionary<string, object>? GetStockPriceQuote(string stockSymbol)
        {
            throw new NotImplementedException();
        }
    }
}
