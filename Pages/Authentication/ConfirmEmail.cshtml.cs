using ITStepRazorApp.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITStepRazorApp.Pages.Authentication
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ConfirmEmailModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [TempData]
        public string StatusMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(string userId,string code)
        {
            if(userId is null || code is null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) 
            {
                return NotFound("User not found.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);

            StatusMessage = result.Succeeded ? "Thank you for confirming your email" : "Email confirmation failed";

            return Page();
        }
    }
}
