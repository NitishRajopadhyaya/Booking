namespace Services.ArenaRegister
{
    public class ArenaRegisterService : IArenaRegisterService
    {
        //private UserManager<ApplicationUser> _userManager;
        //private readonly IJsonResponse _jsonResponse;
        //public ArenaRegisterService(UserManager<ApplicationUser> userManager,IJsonResponse jsonResponse)
        //{
        //    _userManager = userManager;
        //    _jsonResponse = jsonResponse;
        //}
        //public async Task<JsonResponse> Register(RegisterViewModel model)
        //{
        //    try
        //    {
        //        ApplicationUser user = new ApplicationUser() { UserName = model.FullName,PhoneNumber=model.PhoneNumber, Email = model.Email, };
        //        var userData = await _userManager.CreateAsync(user, model.Password);
        //        if (!userData.Succeeded)
        //        {
        //            string message = "some error Occured Please Try again !";
        //            foreach (var item in userData.Errors)
        //            {
        //                message = item.Description + "\n";
        //            }
        //            return _jsonResponse.JsonResult(false,ResponseType.ValidationError, message, null);
        //        }
        //        return  _jsonResponse.JsonResult(true, ResponseType.Success, "", null);
        //    }
        //    catch (Exception ex)
        //    {
        //        return _jsonResponse.JsonResult(false, ResponseType.Exception, ex.Message, null);
        //    }
        //}
    }
}
