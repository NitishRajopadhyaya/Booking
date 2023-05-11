using Microsoft.AspNetCore.Mvc;
using Models.Futsal.models;
using Services.Venue;

namespace OnlineBooking.Components.FeatureAds
{
    public class FeatureAdsViewComponent : ViewComponent
    {
        private readonly IVenueService _venueService;
        public FeatureAdsViewComponent(IVenueService venueService)
        {
            _venueService = venueService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<VenueListViewModel> model = await _venueService.GetVenueDetail();


            return View(model);
        }
    }
}
