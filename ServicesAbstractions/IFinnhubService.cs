namespace ServicesAbstractions
{
    public interface IFinnhubService
    {
        Task<Dictionary<String, object>?> GetStockPriceQuote(string stockSymbol);
        Task<Dictionary<String, object>?> GetStockSymbolInfo(string stockSymbol);
    }
}
