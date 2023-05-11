using Core.Web.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Futsal.models.Booking;
using Models.Futsal.models.Schedule;
using Services.Schedule;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineBooking.Apis
{
    [Route("api/v1/")]
    public class ScheduleController : BaseApiController
    {
        private readonly IScheduleService _scheduleService;
        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        [HttpPost]
        [Route("CreateBookingSchedule")]
        public async Task<ApiResponse> CreateBookingSchedule([FromBody] ScheduleModel schedulemodel)
          {
            try
            {
                schedulemodel.Time = string.Join(",", schedulemodel.ScheduleTime.ToArray());
                var response = await _scheduleService.ScheduleCrudService.InsertAsync<int>(schedulemodel);
                return HttpResponse(200, "", response);
            }
            catch (Exception ex)
            {
                return HttpResponse(500, ex.Message, "");
            }
        }
        [HttpGet]
        [Route("GetEvents")]
        public async Task<ApiResponse> GetEvents()
        {
            try
            {
              
                IEnumerable<EventModel> response = await _scheduleService.GetBookingSchedule(1);
        
                return HttpResponse(200, "", response);
            }
            catch (Exception ex)
            {
                //return Json("Exception.");
                return HttpResponse(500, ex.Message, "");
            }
        }

       

    }
}
