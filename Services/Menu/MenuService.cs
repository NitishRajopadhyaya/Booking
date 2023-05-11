using Core.Data;
using Dapper;
using Models.Futsal.models.Schedule;
using Models.Menu;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Menu
{
    public class MenuService:IMenuService
    {
        public async Task<IEnumerable<MenuModel>> GetMenuList()
        {

            IEnumerable<MenuModel> list;
            var dbfactory = DbFactoryProvider.GetFactory();
            using (var db = (SqlConnection)dbfactory.GetConnection())
            {
                list = await db.QueryAsync<MenuModel>("Select MenuName,Url,AreaName,ControllerName,ActionName,QueryString,* from Menu where IsActive=1 and IsDeleted=0 order by DispalyOrder");
            }
            return list;
        }
    }
}
