using DashboardFinnhub.Models;
using Microsoft.AspNetCore.Mvc;

namespace DashboardFinnhub.Components
{
    [ViewComponent]
    public class TableStockInfoViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Stock stock)
        {
            return View(stock);
        }
    }
}
