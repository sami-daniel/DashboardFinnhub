using DashboardFinnhub.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesAbstractions;
using System.Globalization;

namespace DashboardFinnhub.Controllers
{
    public class HomeController(IFinnhubService finnhubService) : Controller
    {
        readonly IFinnhubService _finnhubService = finnhubService;
        [Route("/")]
        public async Task<IActionResult> Index([FromQuery] string symbol = "ALL")
        {
            symbol.ToUpper();
            List<string> stockSymbols =
            [
                "AAPL", "GOOGL", "MSFT"
            ];
            List<Stock> stocks = [];
            if (symbol == "ALL")
            {
                foreach (var item in stockSymbols)
                {
                    Dictionary<string, object>? response = await _finnhubService.GetStockPriceQuote(item);
                    double? c = TryParse(response?["c"]?.ToString());
                    double? h = TryParse(response?["h"]?.ToString());
                    double? l = TryParse(response?["l"]?.ToString());
                    double? o = TryParse(response?["o"]?.ToString());
                    double? pc = TryParse(response?["pc"]?.ToString());
                    stocks.Add(new Stock(c, h, l, o, pc));
                }
            }
            else
            {
                foreach (var item in stockSymbols.Where(s => s.Contains("AAPL")))
                {
                    Dictionary<string, object>? response = await _finnhubService.GetStockPriceQuote(item);
                    double? c = TryParse(response?["c"]?.ToString());
                    double? h = TryParse(response?["h"]?.ToString());
                    double? l = TryParse(response?["l"]?.ToString());
                    double? o = TryParse(response?["o"]?.ToString());
                    double? pc = TryParse(response?["pc"]?.ToString());
                    stocks.Add(new Stock(c, h, l, o, pc));
                }
            }
            return View();
        }

        private static double? TryParse(string? input)
        {
            if (input == null) return null;
            double result;
            var sucess = double.TryParse(input, CultureInfo.InvariantCulture, out result);
            return sucess ? result : null;
        }
    }
}
