using Core.Data;
using Core.Data.CRUD;
using Dapper;
using Models.Futsal.models;
using Models.Futsal.models.Schedule;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Schedule
{
    public class ScheduleService:IScheduleService
    {
        public CrudService<ScheduleModel> ScheduleCrudService { get; set; }= new CrudService<ScheduleModel> ();
        public async Task<IEnumerable<EventModel>> GetBookingSchedule(int Id)
        {

            IEnumerable<EventModel> list;
            var dbfactory = DbFactoryProvider.GetFactory();
            using (var db = (SqlConnection)dbfactory.GetConnection())
            {
                list = await db.QueryAsync<EventModel>("select * From VW_TIME where VenueId=@venueId", new {@venueId=Id });
            }
            return list;
        }

    }
}
