using Core.Data.CRUD;
using Models.Futsal.models;

namespace Services.Venue
{
    public interface IVenueService
    {
        //Task<List<VenueModel>> GetListAsync();
        //Task<JsonResponse> Create(VenueModel model);
        CrudService<VenueModel> VenueCrudService { get; set; }
        Task<IEnumerable<VenueListViewModel>> GetVenueDetail();

    }
}
