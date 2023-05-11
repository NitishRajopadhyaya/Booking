using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Futsal.models.Booking;
using Services.ManageTime;
using Services.Venue;

namespace OnlineBooking.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IManageTimeService _manageTimeService;
        private readonly IVenueService _venueService;
        public BookingController(IManageTimeService manageTimeService, IVenueService venueService)
        {
            _manageTimeService = manageTimeService;
            _venueService = venueService;
        }
        public async Task<IActionResult> BookingCalendar()
        {
            return View();
        }
        public async Task<IActionResult> BookNow(int Id)
        {
            VenueBookingTimeModel model = await _manageTimeService.GetVenuBookingDetail(Id);

            return View(model);
        }
    }
}
