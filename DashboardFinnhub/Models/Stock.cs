namespace DashboardFinnhub.Models
{
    public class Stock(string? symbol, double? c, double? h,
        double? l, double? o, double? pc, 
        string? country, string? siteUrl, 
        string? exchange, string? industry, 
        string? estimateCurrency, string? name)
    {
        public string? Symbol { get; } = symbol;
        public double? CurrentPrice { get; } = c;
        public double? HighPriceoftheDay { get; } = h;
        public double? LowPriceoftheDay { get; } = l;
        public double? OpenPriceoftheDay { get; } = o;
        public double? PreviousClosePrice { get; } = pc;
        public string? Country { get; } = country;
        public string? SiteURL { get; } = siteUrl;
        public string? Exchange { get; } = exchange;
        public string? Industry { get; } = industry;
        public string? EstimateCurrency { get; } = estimateCurrency;
        public string? Name { get; } = name;
    }
}
