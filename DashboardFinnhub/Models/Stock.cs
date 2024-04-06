namespace DashboardFinnhub.Models
{
<<<<<<< HEAD
    public class Stock(double? c, double? h, double? l, double? o, double? pc)
=======
    public class Stock(double c, double h, double l, double o, double pc)
>>>>>>> 4dfc53b3ca0c829b32f2611a57e66a935d105b14
    {
        public double? CurrentPrice { get; } = c;
        public double? HighPriceoftheDay{ get; } = h;
        public double? LowPriceoftheDay { get; } = l;
        public double? OpenPriceoftheDay { get; } = o;
        public double? PreviousClosePrice { get; } = pc;
    }
}
