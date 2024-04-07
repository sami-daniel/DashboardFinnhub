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
        public async Task<IActionResult> Index([FromQuery] string stockSymbol = "AAPL")
        {
            var symbol = stockSymbol.ToUpper();
            var stocks = new List<Stock>();
            Dictionary<string, object>? response = await _finnhubService.GetStockPriceQuote(symbol);
            response.Remove("d");
            response.Remove("dp");
            response.Remove("t");
            if (response!.ContainsKey("error") || response.All(item => TryParse(item.Value.ToString()) == 0d))
            {
                return NotFound("The Stock Symbol cant be found");
            }
            double? c = TryParse(response?["c"]?.ToString());
            double? h = TryParse(response?["h"]?.ToString());
            double? l = TryParse(response?["l"]?.ToString());
            double? o = TryParse(response?["o"]?.ToString());
            double? pc = TryParse(response?["pc"]?.ToString());
            stocks.Add(new Stock(symbol, c, h, l, o, pc));

            return View(stocks);
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
