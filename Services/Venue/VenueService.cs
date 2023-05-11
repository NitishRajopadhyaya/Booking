using Core.Data;
using Core.Data.CRUD;
using Core.Web;
using Dapper;
using Models.Futsal.models;
//using Repository.Repository.Venu;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Services.Venue
{
    public class VenueService: IVenueService// BaseCrudService, 
    {
        //private readonly IVenueRepository _venueRepository;
        private readonly IJsonResponse _jsonResponse;
        private const string sp_Venue_Write = "PROC_VENUE";
        public VenueService(/*IVenueRepository venueRepository,*/ IJsonResponse jsonResponse )
        {
            //_venueRepository = venueRepository;
            _jsonResponse = jsonResponse;
        }

        public CrudService<VenueModel> VenueCrudService { get; set; }= new CrudService<VenueModel>();


        public async Task<IEnumerable<VenueListViewModel>> GetVenueDetail()
        {

            IEnumerable<VenueListViewModel> list;
            var dbfactory = DbFactoryProvider.GetFactory();
            using (var db = (SqlConnection)dbfactory.GetConnection())
            {
               list= await db.QueryAsync<VenueListViewModel>("select VenueId,VenueName,VenueDescription from Venue");
            }
            return list;
        }


        //public async Task<List<VenueModel>> GetListAsync()
        //{
        //    var query = "select * from Venue";
        //    DynamicParameters p = new DynamicParameters();
        //    var list =await _venueRepository.GetListAsync<VenueModel>(query, p);
        //    return list;
        //}
        //public async Task<JsonResponse> Create(VenueModel model)
        //{
        //    DynamicParameters parameters = new DynamicParameters();
        //    parameters.Add("@VenueId", model.VenueId, direction: ParameterDirection.Output, size: sizeof(int));
        //    parameters.Add("@VenueName", model.VenueName);
        //    parameters.Add("@VenueNameNepali", model.VenueNameNepali);
        //    parameters.Add("@VenueLength", model.VenueLength);
        //    parameters.Add("@VenueWidth", model.VenueWidth);
        //    parameters.Add("@VenueTypeId", model.VenueTypeId);
        //    //parameters.Add("@OpeningTime", model.OpeningTime);
        //    //parameters.Add("@ClosingTime", model.ClosingTime);
        //    parameters.Add("@VenueDescription", model.VenueDescription);
        //    parameters.Add("@IsVenueActive", model.IsVenueActive);
        //    SetParamsForCrud(parameters, CrudMode.Insert);

        //    await _venueRepository.ExecuteAsync(sp_Venue_Write, parameters);

        //    var spOutparams = GetSpOutParamResult(parameters, "@VenueId");
        //    model.VenueId = spOutparams.RowId;

        //    if (spOutparams.ErrorFlag == "Y") return _jsonResponse.JsonExceptionResult(spOutparams.ErrorMsg);
        //    return await _jsonResponse.JsonResultAsync(true, ResponseType.Added, "Venue Added Successfully", model);
        //}
        //public async Task<VenueModel>GetVenueById(int VenueId)
        //{
        //    var query = "select * from Venue where VenueId="+VenueId;
        //    DynamicParameters p = new DynamicParameters();
        //    var venueData = await _venueRepository.get
        //    return venueData;
        //}

    }
}
