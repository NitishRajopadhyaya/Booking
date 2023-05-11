using Core.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Common.Models.Users;
using Security.Models;
using System.Data.SqlClient;
using System.Security.Principal;
using IdentityUser = Security.Models.IdentityUser;

namespace OnlineBooking.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class RegistrationController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public RegistrationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, PhoneNumber = model.PhoneNumber, Email = model.Email, UserType = "Owner" };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    //  _logger.LogInformation("User created a new account with password.");

                    // var contentUserCreated = "Your user has been created";
                    //  var UserCreated = await _emailService.SendEmail("UserCreated", model.Email, contentUserCreated);

                    //var dbfactory = DbFactoryProvider.GetFactory();
                    //using (var db = (SqlConnection)dbfactory.GetConnection())
                    //{
                    //    await db.ExecuteAsync("Insert into IdentityUserRole(UserId,RoleId)values(@UserId, @RoleId)", new { UserId = user.Id, RoleId = 4 });
                    //}
                    //var IsNewUserVerificationRequired = _account.IsTrueSettingValue();
                    //if (IsNewUserVerificationRequired.Result == true)
                    //{
                    //    Guid id = Guid.NewGuid();
                    //    UserVerify uv = new UserVerify();
                    //    uv.Code = Convert.ToString(id);
                    //    var getUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                    //    uv.Status = EnumDataStatus.New;
                    //    uv.IdentityUserId = user.Id;
                    //    uv.IssueDate = DateTime.Now;
                    //    var IsertData = await _account.InsertAsync(uv, model.Email);
                    //    var content = "Please click " + " " + getUrl + "/Account/EmailVerification" + "?Code=" + uv.Code + " " + "for veryfying your account";
                    //    var sent = await _emailService.SendEmail("VerificationUser", model.Email, content);
                    //    TempData["Message"] = "Please Check Your Email To Verify Your Account";
                    //    return Redirect(Url.Content("~/"));
                    //}
                    //else
                    //{
                    //    return Redirect("/account/login");
                    //}

                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    var message = "";
                    foreach (var items in result.Errors)
                    {
                        message = items.Description;
                    }
                    // _notification.Notify(message, NotificationType.Warning);
                    AddErrors(result);
                }

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return Redirect("/");
            }
        }

        #endregion
    }
}
