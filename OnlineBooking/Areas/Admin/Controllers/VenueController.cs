using Core.Enum;
using Core.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Futsal.models;
using Security.Extensions;
using Services.Venue;

namespace OnlineBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class VenueController : Controller
    {
        private readonly IVenueService _VenuService;

        // private readonly 
        public VenueController(IVenueService venueService)
        {
            _VenuService = venueService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<VenueModel> model = await _VenuService.VenueCrudService.GetListAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VenueModel model)
        {
            if (ModelState.IsValid)
            {
                model.AutoFill();
                await _VenuService.VenueCrudService.InsertAsync(model);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int VenueId)
        {
            VenueModel model = await _VenuService.VenueCrudService.GetAsync(VenueId);
            return View(model);
        }

        public async Task<IActionResult> Edit(VenueModel model)
        {
            if (ModelState.IsValid)
            {
                model.AutoFill();
                await _VenuService.VenueCrudService.UpdateAsync(model);
            }
            return View(model);
        }
    }
}
