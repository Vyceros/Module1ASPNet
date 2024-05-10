using ITStepRazorApp.Data.Model;
using ITStepRazorApp.Data.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITStepRazorApp.Pages.Authentication
{
    public class VerifyAuthenticationCodeModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public VerifyAuthenticationCodeModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public VerifyAuthenticatorViewModel Model = new();

        public async Task<IActionResult> OnGet(bool rememberMe, string? returnUrl)
        {
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

            if (user == null)
            {
                return NotFound("User not found");
            }

            Model.ReturnUrl = returnUrl;
            Model.RememberMe = rememberMe;

            return Page();

        }

        public async Task<IActionResult> OnPostAsync(VerifyAuthenticatorViewModel model)
        {
            model.ReturnUrl = model.ReturnUrl ?? Url.Content("~/");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(model.Code, model.RememberMe, rememberClient: false);

            if (result.Succeeded)
            {
                return LocalRedirect(model.ReturnUrl);
            }
            else if (result.IsLockedOut)
            {
                return RedirectToPage("/Authentication/Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid code");
                return Page();
            }
        }
    }
}
