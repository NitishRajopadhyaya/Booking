using Microsoft.AspNetCore.Mvc;
using Models.Menu;
using Services.Menu;

namespace OnlineBooking.Components.SideMenu
{
    public class SideMenuViewComponent : ViewComponent
    {
        private readonly IMenuService _menuService;
        public SideMenuViewComponent(IMenuService menuService)
        {
            _menuService = menuService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<MenuModel> list=  await _menuService.GetMenuList();


            return View(list);
        }
    }
}
