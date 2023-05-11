using Microsoft.AspNetCore.Mvc;
using Models.Futsal.models;
using OnlineBooking.Models;
using Services.Venue;
using System.Diagnostics;

namespace OnlineBooking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVenueService _venueService;
        public HomeController(ILogger<HomeController> logger, IVenueService venueService)
        {
            _logger = logger;
            _venueService = venueService;
        }

        public async Task<IActionResult> Index()
        {
            // IEnumerable<VenueListViewModel> model = await _venueService.GetVenueDetail();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}