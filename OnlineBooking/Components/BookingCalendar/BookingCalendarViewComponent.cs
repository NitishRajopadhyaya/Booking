using Microsoft.AspNetCore.Mvc;

namespace OnlineBooking.Components.BookingCalendar
{
    public class BookingCalendarViewComponent : ViewComponent
    {
        public BookingCalendarViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
