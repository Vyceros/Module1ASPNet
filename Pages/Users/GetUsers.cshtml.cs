using ITStepRazorApp.Data.ViewModel.User;
using ITStepRazorApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ITStepRazorApp.Data.Model;

namespace ITStepRazorApp.Pages.Users
{
	public class GetUsersModel : PageModel
	{
		private readonly ApplicationDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		public GetUsersModel(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
		{
			_db = db;
			_userManager = userManager;
		}

		public List<UserViewModel> Users = new();

		public async Task<IActionResult> OnGetAsync()
		{
			var users = await _db.Users.ToListAsync();
			var roles = await _db.Roles.ToListAsync();
			var userRoles = await _db.UserRoles.ToListAsync();

			foreach (var user in users)
			{
				var userViewModel = new UserViewModel();

				var userRole = userRoles.FirstOrDefault(ur => ur.UserId == user.Id);

				userViewModel.Id = user.Id;
				userViewModel.UserName = user.UserName;
				userViewModel.Role = roles.FirstOrDefault(r => r.Id == userRole.RoleId).Name;
				userViewModel.EmailConfirmed = user.EmailConfirmed;
				userViewModel.TwoFactorEnabled = user.TwoFactorEnabled;
				userViewModel.LockoutEnd = user.LockoutEnd;

				Users.Add(userViewModel);
			}

			return Page();
		}
	}
}
