using ITStepRazorApp.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITStepRazorApp.Pages.Authentication
{
    public class ProfileModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                ViewData["TwoFactorEnabled"] = false;
            }
            else
            {
                ViewData["TwoFactorEnabled"] = user.TwoFactorEnabled;
            }

            return Page();
        }
    }
}
