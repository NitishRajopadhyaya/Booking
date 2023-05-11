using Microsoft.AspNetCore.Mvc;

namespace OnlineBooking.Components
{
    public class BannerViewComponent : ViewComponent
    {
        public BannerViewComponent()
        {
            
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
