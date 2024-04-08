using ITStepRazorApp.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ITStepRazorApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        
        DbSet<KhachapuriOrder> khachapuriOrders {  get; set; }
        DbSet<LobianiOrder> lobianiOrders { get; set; }
        DbSet<KhinkaliOrder> khinkaliOrders { get; set; }
        DbSet<MtsvadiOrder> mtsvadiOrders { get; set; }

    }
}
