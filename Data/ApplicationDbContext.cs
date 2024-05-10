using ITStepRazorApp.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITStepRazorApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<PizzaModel> PizzaModel { get; set; }
        public DbSet<ApplicationUser> AppUser { get; set; }


    }
}
