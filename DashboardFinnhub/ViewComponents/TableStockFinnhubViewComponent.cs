using DashboardFinnhub.Models;
using Microsoft.AspNetCore.Mvc;

namespace DashboardFinnhub.ViewComponents
{
    [ViewComponent]
    public class TableStockFinnhubViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Stock stock)
        {
            return View(stock);
        }
    }
}
