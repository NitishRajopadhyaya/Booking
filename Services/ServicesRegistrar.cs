using Core.DI;
using Microsoft.Extensions.DependencyInjection;
using Services.ManageTime;
using Services.Menu;
using Services.Schedule;
using Services.Venue;

namespace Services
{
    public class ServicesRegistrar : IServiceRegistrar
    {
        public void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IVenueService, VenueService>();
            serviceCollection.AddSingleton<IManageTimeService, ManageTimeService>();
            serviceCollection.AddSingleton<IScheduleService, ScheduleService>();
            serviceCollection.AddSingleton<IMenuService, MenuService>();
           
        }
    }
}