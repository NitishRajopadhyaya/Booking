using Core.Data.CRUD;
using Core.Struct;
using Models.Futsal.models;
using Models.Futsal.models.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ManageTime
{
    public interface IManageTimeService
    {
        CrudService<ManageDayTimeModel> ManageDayTimeCrudService { get; set; }
        CrudService<ManageTimeModel> ManageTimeCrudSerce { get; set; }
        Task<VenueBookingTimeModel> GetVenuBookingDetail(int VenueId);
        Task<IEnumerable<TimeRange>> VenueBookingTime(int venueId);
    }
}
