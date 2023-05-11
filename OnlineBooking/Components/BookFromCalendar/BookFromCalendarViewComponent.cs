using Microsoft.AspNetCore.Mvc;

namespace OnlineBooking.Components.BookFromCalendar
{
    public class BookFromCalendarViewComponent : ViewComponent
    {
        public BookFromCalendarViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
