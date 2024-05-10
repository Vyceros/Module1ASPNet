using ITStepRazorApp.Data;
using ITStepRazorApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ITStepRazorApp.Pages.User
{
    public class EditUserModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditUserModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public ApplicationUser User { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId)
        {
            User = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _db.Attach(User).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/User/GetUsers");
        }

        private bool UserExists(string id)
        {
            return _db.Users.Any(u => u.Id == id);
        }
    }
}