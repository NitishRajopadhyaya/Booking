using Microsoft.AspNetCore.Mvc;

namespace OnlineBooking.Components
{
    public class PopularViewComponent : ViewComponent
    {
        public PopularViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
