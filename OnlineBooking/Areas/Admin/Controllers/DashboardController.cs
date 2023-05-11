using Microsoft.AspNetCore.Mvc;

namespace OnlineBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public DashboardController()
        {

        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
