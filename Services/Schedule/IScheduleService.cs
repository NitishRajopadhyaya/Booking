using Core.Data.CRUD;
using Models.Futsal.models.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Schedule
{
    public interface IScheduleService
    {
        CrudService<ScheduleModel> ScheduleCrudService { get; set; }
        Task<IEnumerable<EventModel>> GetBookingSchedule(int Id);
    }
}
