using Core.Data;
using Core.Data.CRUD;
using Core.Struct;
using Dapper;
using Models.Futsal.models;
using Models.Futsal.models.Booking;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Services.ManageTime
{
    public class ManageTimeService : IManageTimeService
    {
        public CrudService<ManageTimeModel> ManageTimeCrudSerce { get; set; } = new CrudService<ManageTimeModel>();
        public CrudService<ManageDayTimeModel> ManageDayTimeCrudService { get; set; } = new CrudService<ManageDayTimeModel>();

        public async Task<VenueBookingTimeModel> GetVenuBookingDetail(int VenueId)
        {
            VenueBookingTimeModel result = new VenueBookingTimeModel();
            try
            {
                var dbfactory = DbFactoryProvider.GetFactory();
                using (var db = (SqlConnection)dbfactory.GetConnection())
                {
                    result = await db.QueryFirstAsync<VenueBookingTimeModel>(@"select mdt.ManageDayTimeId,v.VenueId,v.VenueDescription ,v.VenueName,mt.ManageTimeId,
                             mt.Price,mdt.SunStartDateTime,mdt.SunEndDateTime,SunRange,mdt.MonStartDateTime,mdt.MonEndDateTime,mdt.MonRange,mdt.TueStartDateTime,
                             mdt.TueEndDateTime,mdt.TueRange,mdt.WedStartDateTime,mdt.WedEndDateTime,mdt.WedRange,mdt.ThurStartDateTime,mdt.ThurEndDateTime,mdt.ThurRange,
                             mdt.FriStartDateTime,mdt.FriEndDateTime,mdt.FriRange,mdt.SatStartDateTime,mdt.SatEndDateTime,mdt.SatRange,mt.IsActive
                             from ManageTime mt
                             inner join ManageDayTime mdt on mdt.ManageTimeId =mt.ManageTimeId
                             inner join Venue v on v.VenueId=mt.VenueId where v.VenueId=@venueId", new { @venueId = VenueId });

                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<IEnumerable<TimeRange>> VenueBookingTime(int venueId)
        {


            DayOfWeek day = DateTime.Now.DayOfWeek;
            var result = await GetVenuBookingDetail(venueId);
            IEnumerable<TimeRange> ranges = new List<TimeRange>();

            switch (day)
            {
                case DayOfWeek.Sunday:
                    ranges = await GetTimeList(result.SunStartDateTime, result.SunEndDateTime, result.SunRange);
                    break;
                case DayOfWeek.Monday:
                    ranges = await GetTimeList(result.MonStartDateTime, result.MonEndDateTime, result.MonRange);
                    break;
                case DayOfWeek.Tuesday:
                    ranges = await GetTimeList(result.TueStartDateTime, result.TueEndDateTime, result.TueRange);
                    break;
                case DayOfWeek.Wednesday:
                    ranges = await GetTimeList(result.WedStartDateTime, result.WedEndDateTime, result.WedRange);
                    break;
                case DayOfWeek.Thursday:
                    ranges = await GetTimeList(result.ThurStartDateTime, result.ThurEndDateTime, result.ThurRange);
                    break;
                case DayOfWeek.Friday:
                    ranges = await GetTimeList(result.FriStartDateTime, result.FriEndDateTime, result.FriRange);
                    break;
                case DayOfWeek.Saturday:
                    ranges = await GetTimeList(result.SatStartDateTime, result.SatEndDateTime, result.SatRange);
                    break;
            }
            return ranges;
        }


        private async Task<IEnumerable<TimeRange>> GetTimeList(string StartDate, string EndDate, int range)
        {

            DateTime startTime = DateTime.Parse(StartDate); // example start time
            DateTime endTime = DateTime.Parse(EndDate);

            TimeRange timeRange = new TimeRange(startTime, endTime - startTime);

            IEnumerable<TimeRange> intervals = timeRange.Split(new TimeSpan(1, 0, 0));

            return intervals;
            //var todayDate = DateTime.Now.ToShortDateString();
            //string start = string.Concat(todayDate, ' ', StartDate);

            //DateTime time = DateTime.ParseExact(EndDate, "HH:mm", CultureInfo.InvariantCulture);
            //string time24 = time.ToString("hh:mm");
            //string[] split = time24.Split(':');
            //int hr = Convert.ToInt16(split[0]);
            //int min = Convert.ToInt16(split[1]);
            //TimeRange mainRange = new TimeRange(Convert.ToDateTime(start), new TimeSpan(hr, min, 0)); // completed
            //List<TimeRange> rangeList = mainRange.Split(new TimeSpan(1, 0, 0)).ToList();
            //return rangeList;

        }
    }
}
