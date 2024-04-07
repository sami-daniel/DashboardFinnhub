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
        public async Task<IActionResult> Index([FromQuery] string symbol = "AAPL")
        {
            ViewBag.Title = "Home Page";
            var stocks = new List<Stock>();
            Dictionary<string, object>? stockQuote = await _finnhubService.GetStockPriceQuote(symbol);
            Dictionary<string, object>? stockInfoProfile = await _finnhubService.GetStockSymbolInfo(symbol);
            stockQuote!.Remove("d");
            stockQuote!.Remove("dp");
            stockQuote!.Remove("t");
            if (stockQuote!.ContainsKey("error") || stockQuote.All(item => TryParse(item.Value.ToString()) == 0d) || stockInfoProfile!.All(item => item.Value.ToString() == string.Empty))
            {
                return NotFound("The Stock Symbol cant be found");
            }
            double? c = TryParse(stockQuote?["c"]?.ToString());
            double? h = TryParse(stockQuote?["h"]?.ToString());
            double? l = TryParse(stockQuote?["l"]?.ToString());
            double? o = TryParse(stockQuote?["o"]?.ToString());
            double? pc = TryParse(stockQuote?["pc"]?.ToString());
            string? country = stockInfoProfile?["country"]?.ToString();
            string? siteUrl = stockInfoProfile?["weburl"]?.ToString();
            string? exchange = stockInfoProfile?["exchange"]?.ToString();
            string? industry = stockInfoProfile?["finnhubIndustry"]?.ToString();
            string? estimateCurrency = stockInfoProfile?["estimateCurrency"]?.ToString();
            string? name = stockInfoProfile?["name"]?.ToString();
            stocks.Add(new Stock(symbol.ToUpper(), c, h, l, o, pc, country, siteUrl, exchange, industry, estimateCurrency, name));

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
