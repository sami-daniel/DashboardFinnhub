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
        public IActionResult Index([FromQuery] string symbol = "ALL")
        {
            
        }

        private double? TryParse(string input)
        {
            double result;
            var sucess = double.TryParse(input, CultureInfo.InvariantCulture, out result);
            return sucess ? result : null;
        }
    }
}
