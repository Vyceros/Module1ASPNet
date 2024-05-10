using Microsoft.AspNetCore.Identity;

namespace ITStepRazorApp.Data.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
