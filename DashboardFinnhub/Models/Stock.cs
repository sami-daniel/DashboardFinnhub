namespace DashboardFinnhub.Models
{
    public class Stock(string? name, double? c, double? h, double? l, double? o, double? pc)
    {
        public string? Name { get; } = name;
        public double? CurrentPrice { get; } = c;
        public double? HighPriceoftheDay { get; } = h;
        public double? LowPriceoftheDay { get; } = l;
        public double? OpenPriceoftheDay { get; } = o;
        public double? PreviousClosePrice { get; } = pc;
    }
}
