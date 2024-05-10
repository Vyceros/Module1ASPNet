using ITStepRazorApp.Data.Model;
using ITStepRazorApp.Data.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Encodings.Web;

namespace ITStepRazorApp.Pages.Authentication
{
    public class EnableTwoFactorModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UrlEncoder _urlEncoder;
        public TwoFactorAuthenticationViewModel Model { get; set; }

        public EnableTwoFactorModel(UserManager<ApplicationUser> userManager, UrlEncoder urlEncoder)
        {
            _userManager = userManager;
            _urlEncoder = urlEncoder;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            string authenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=4";
            var user = await _userManager.GetUserAsync(User);

            // resetting previously registered authentication
            // User - application global user
            await _userManager.ResetAuthenticatorKeyAsync(user);

            var token = await _userManager.GetAuthenticatorKeyAsync(user);

            string authenticatorUri = string.Format(authenticatorUriFormat, _urlEncoder.Encode("ITStepRazor"),
                _urlEncoder.Encode(user.Email), token);

            var model = new TwoFactorAuthenticationViewModel()
            {
                Token = token,
                QRCodeUrl = authenticatorUri
            };

            Model = model;

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(TwoFactorAuthenticationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                var succeeded = await _userManager.VerifyTwoFactorTokenAsync(user, _userManager.Options.Tokens.AuthenticatorTokenProvider, model.Code);

                if (succeeded)
                {
                    var result = await _userManager.SetTwoFactorEnabledAsync(user, true);
                }
                else
                {
                    ModelState.AddModelError("Verify", "Your two factor auth code could not be validated");
                    return Page();
                }
            }

            return RedirectToPage("/Authentication/AuthenticationConfirmation");
        }
    }
}
