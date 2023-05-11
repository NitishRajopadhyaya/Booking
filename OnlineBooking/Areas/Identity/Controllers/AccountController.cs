//using Core.Extensions;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Models.Common.Models.Users;
using Models.Identity;
using Security.Models;
using Security.Services;
using System.Security.Principal;
using System.Text;
using IdentityUser = Security.Models.IdentityUser;


namespace OnlineBooking.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IIdentityUserService _identityUserService;
        //private readonly IIdentityServerInteractionService _interaction;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager, 
                                IIdentityUserService identityUserService) 
                                //IIdentityServerInteractionService interaction, 
                                //IHttpContextAccessor httpContextAccessor
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _identityUserService = identityUserService;
            //_interaction = interaction;
            //_httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> Register(RegisterViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, PhoneNumber = model.PhoneNumber, Email = model.Email, UserType = "User" };
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

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
           
            returnUrl ??= Url.Content("~/");
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl =null  )
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    IdentityUser user = await _identityUserService.UserService.GetAsync("where Email=@Email ", new { @Email = model.Email });
                    //_logger.LogInformation("User logged in.");
                    if (returnUrl == null && user.UserType != "User")
                    {
                        //SettingLoginRedirect loginRedirect = await _settingService.SettingLoginRedirectCrudService.GetAsync("where UserType=@UserType", new { @UserType = user.UserType });
                        //returnUrl = loginRedirect != null ? loginRedirect.RedirectUrl : "";
                        model.ReturnUrl = "/Admin/Dashboard/Index";
                        return RedirectToLocal(model.ReturnUrl);
                    }

                    return RedirectToLocal(returnUrl);
                }

                //if (result.RequiresTwoFactor)
                //{
                //    return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
                //}
                //if (result.IsLockedOut)
                //{
                // //   _logger.LogWarning("User account locked out.");
                //    return RedirectToAction(nameof(Lockout));
                //}
                else
                {
                    TempData["ErrorLoginMsg"] = "Error ! Invalid login attempt";
                    // _notification.Notify("Invalid login attempt", NotificationType.Error);
                    //(.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        // async Task<IActionResult> Logout(LogOutInputModel model)
        //{
        //    var vm = await BuildLoggedOutViewModelAsync(model.LogoutId);

        //    await _signInManager.SignOutAsync();
        //    //_logger.LogInformation("User logged out.");

        //    // check if we need to trigger sign-out at an upstream identity provider
        //    if (vm.TriggerExternalSignout)
        //    {
        //        // build a return URL so the upstream provider will redirect back
        //        // to us after the user has logged out. this allows us to then
        //        // complete our single sign-out processing.
        //        string url = Url.Action("Logout", new { logoutId = vm.LogoutId });

        //        // this triggers a redirect to the external provider for sign-out
        //        // hack: try/catch to handle social providers that throw
        //        return SignOut(new AuthenticationProperties { RedirectUri = url }, vm.ExternalAuthenticationScheme);
        //    }
        //    HttpContext.Session.Clear();
        //    return Redirect(Url.Content("~/"));
        //}
        //private async Task<LoggedOutViewModel> BuildLoggedOutViewModelAsync(string logoutId)
        //{
        //    // get context information (client name, post logout redirect URI and iframe for federated signout)
        //    var logout = await _interaction.GetLogoutContextAsync(logoutId);

        //    var vm = new LoggedOutViewModel
        //    {
        //        AutomaticRedirectAfterSignOut = AccountOptions.AutomaticRedirectAfterSignOut,
        //        PostLogoutRedirectUri = logout?.PostLogoutRedirectUri,
        //        ClientName = logout?.ClientId,
        //        SignOutIframeUrl = logout?.SignOutIFrameUrl,
        //        LogoutId = logoutId
        //    };

        //    var user = _httpContextAccessor.HttpContext?.User;
        //    if (user.Identity.IsAuthenticated == true)
        //    {
        //        var idp = user.FindFirst(JwtClaimTypes.IdentityProvider)?.Value;
        //        if (idp != null && idp != IdentityServer4.IdentityServerConstants.LocalIdentityProvider)
        //        {
        //            var providerSupportsSignout = await _httpContextAccessor.HttpContext.GetSchemeSupportsSignOutAsync(idp);
        //            if (providerSupportsSignout)
        //            {
        //                if (vm.LogoutId == null)
        //                {
        //                    // if there's no current logout context, we need to create one
        //                    // this captures necessary info from the current logged in user
        //                    // before we signout and redirect away to the external IdP for signout
        //                    vm.LogoutId = await _interaction.CreateLogoutContextAsync();
        //                }

        //                vm.ExternalAuthenticationScheme = idp;
        //            }
        //        }
        //    }

        //    return vm;
        //}



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
