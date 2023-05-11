using Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using Models.Futsal.models;
using Services.ManageTime;
using Services.Venue;
using Core.Struct;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography.X509Certificates;
using Core.Data.CRUD;

namespace OnlineBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ManageTimeController : Controller
    {
        private readonly IVenueService _venueService;
        private readonly IManageTimeService _manageTimeService;
        public ManageTimeController(IVenueService venueService, IManageTimeService manageTimeService)
        {
            _venueService = venueService;
            _manageTimeService = manageTimeService;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.VenuList = await _venueService.VenueCrudService.GetListAsync(" where IsVenueActive=@IsVenueActive", new { @IsVenueActive = 1 });

            ViewBag.RangeList = new List<SelectListItem> {
                                                    new SelectListItem { Text = "15", Value = "15" },
                                                    new SelectListItem { Text = "30", Value = "30" }
                                                };
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ManageTimeModel model)
        {
            ManageDayTimeModel timeModel = new ManageDayTimeModel();
            if (ModelState.IsValid)
            {
                model.AutoFill();
                timeModel.ManageTimeId = await _manageTimeService.ManageTimeCrudSerce.InsertAsync<int>(model);
                if(model.manageSundayMultipleTimes!=null)
                {
                    AddMuiltpleTime<ManageSundayMultipleTime>("Sunday", model.manageSundayMultipleTimes);
                }
                if (model.manageMondayMultipleTimes != null)
                {
                    AddMuiltpleTime<ManageMondayMultipleTime>("Monday", model.manageMondayMultipleTimes);
                }
                if (model.manageTuesdayMultipleTimes != null)
                {
                    AddMuiltpleTime<ManageTuesdayMultipleTime>("Tuesday", model.manageTuesdayMultipleTimes);
                }
                if (model.manageWednesdayMultipleTimes != null)
                {
                    AddMuiltpleTime<ManageWednesdayMultipleTime>("Wednesday", model.manageWednesdayMultipleTimes);
                }
                if (model.manageThursdayMultipleTimes != null)
                {
                    AddMuiltpleTime<ManageThursdayMultipleTime>("Thursday", model.manageThursdayMultipleTimes);
                }
                if (model.manageFridayMultipleTimes != null)
                {
                    AddMuiltpleTime<ManageFridayMultipleTime>("Friday", model.manageFridayMultipleTimes);
                }
                if (model.manageSaturdayMultipleTimes != null)
                {
                    AddMuiltpleTime<ManageSaturdayMultipleTime>("Saturday", model.manageSaturdayMultipleTimes);
                }

                timeModel.SunStartDateTime = Convert.ToString(model.manageDayTime.SunStartDateTime);
                timeModel.SunEndDateTime = Convert.ToString(model.manageDayTime.SunEndDateTime);
                timeModel.SunRange = model.manageDayTime.SunRange;
                timeModel.MonStartDateTime = Convert.ToString(model.manageDayTime.MonStartDateTime);
                timeModel.MonEndDateTime = Convert.ToString(model.manageDayTime.MonEndDateTime);
                timeModel.MonRange = model.manageDayTime.MonRange;
                timeModel.TueStartDateTime = Convert.ToString(model.manageDayTime.TueStartDateTime);
                timeModel.TueEndDateTime = Convert.ToString(model.manageDayTime.TueEndDateTime);
                timeModel.TueRange = model.manageDayTime.TueRange;
                timeModel.WedStartDateTime = Convert.ToString(model.manageDayTime.WedStartDateTime);
                timeModel.WedEndDateTime = Convert.ToString(model.manageDayTime.WedEndDateTime);
                timeModel.WedRange = model.manageDayTime.WedRange;
                timeModel.ThurStartDateTime = Convert.ToString(model.manageDayTime.ThurStartDateTime);
                timeModel.ThurEndDateTime = Convert.ToString(model.manageDayTime.ThurEndDateTime);
                timeModel.ThurRange = model.manageDayTime.ThurRange;
                timeModel.FriStartDateTime = Convert.ToString(model.manageDayTime.FriStartDateTime);
                timeModel.FriEndDateTime = Convert.ToString(model.manageDayTime.FriEndDateTime);
                timeModel.FriRange = model.manageDayTime.FriRange;
                timeModel.SatStartDateTime = Convert.ToString(model.manageDayTime.SatStartDateTime);
                timeModel.SatEndDateTime = Convert.ToString(model.manageDayTime.SatEndDateTime);
                timeModel.SatRange = model.manageDayTime.SatRange;

                await _manageTimeService.ManageDayTimeCrudService.InsertAsync(timeModel);

            }
            return View(model);
        }

        public void AddMuiltpleTime<T>(string day, List<T> list)
        {
            CrudService<T> CustomManageDayTimeCrudService  = new CrudService<T>();
            foreach(var item in list)
            {
                
                CustomManageDayTimeCrudService.Insert(item);

            }
        }
        //private string GetrangeVlue()
        //{


        //    TimeRange mainRange = new TimeRange(Convert.ToDateTime("2023/01/01 06:00"), new TimeSpan(6, 30, 0)); // completed
        //    List<TimeRange> rangeList = mainRange.Split(new TimeSpan(2, 0, 0)).ToList();
        //}
    }
}
