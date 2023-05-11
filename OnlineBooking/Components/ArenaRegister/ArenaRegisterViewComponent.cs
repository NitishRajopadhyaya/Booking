using Microsoft.AspNetCore.Mvc;

namespace OnlineBooking.Components.ArenaRegister
{
    public class ArenaRegisterViewComponent : ViewComponent
    {
        public ArenaRegisterViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
