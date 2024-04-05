namespace ServicesAbstractions
{
    public interface IFinnhubService
    {
        Dictionary<String, object>? GetStockPriceQuote(string stockSymbol);
    }
}
