using Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Menu
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuModel>> GetMenuList();
    }
}
