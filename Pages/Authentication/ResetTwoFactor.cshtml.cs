using ITStepRazorApp.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Formats.Asn1;

namespace ITStepRazorApp.Pages.Authentication
{
    public class ResetTwoFactorModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ResetTwoFactorModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);

            await _userManager.ResetAuthenticatorKeyAsync(user);
            await _userManager.SetTwoFactorEnabledAsync(user, false);
            return RedirectToPage("/Index");
        }
    }
}
