using DashboardFinnhub.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesAbstractions;

namespace DashboardFinnhub.Controllers
{
    public class HomeController(IFinnhubService finnhubService) : Controller
    {
        readonly IFinnhubService _finnhubService = finnhubService;
        [Route("/")]
        public IActionResult Index([FromQuery] string symbol = "ALL")
        {
            
            return View();
        }
    }
}
