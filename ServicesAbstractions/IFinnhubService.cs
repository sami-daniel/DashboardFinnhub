namespace ServicesAbstractions
{
    public interface IFinnhubService
    {
        Task<Dictionary<String, object>?> GetStockPriceQuote(string stockSymbol);
    }
}
