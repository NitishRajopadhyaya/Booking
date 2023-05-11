using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Common.Models.Users;

namespace OnlineBooking.Components.ArenaRegister
{
    public class ArenaRegisterController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public ArenaRegisterController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
       // [AllowAnonymous]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email,PhoneNumber=model.PhoneNumber, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                  //  _logger.LogInformation("User created a new account with password.");

                    // var contentUserCreated = "Your user has been created";
                    //  var UserCreated = await _emailService.SendEmail("UserCreated", model.Email, contentUserCreated);


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
