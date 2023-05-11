using Core.Struct;
using Microsoft.AspNetCore.Mvc;
using Models.Futsal.models;
using Models.Futsal.models.Booking;
using Services.ManageTime;
using System.Collections.Generic;

namespace OnlineBooking.Components.BookingTime
{
    public class BookingTimeViewComponent : ViewComponent
    {

        private readonly IManageTimeService _manageTimeService;
        public BookingTimeViewComponent(IManageTimeService manageTimeService)
        {
            _manageTimeService = manageTimeService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int venueId)
        {
            var result = await _manageTimeService.VenueBookingTime(venueId);
            return View(result);
        }
    }
}
