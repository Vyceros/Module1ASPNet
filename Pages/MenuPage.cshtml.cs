using ITStepRazorApp.Data;
using ITStepRazorApp.Data.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ITStepRazorApp.Pages
{
    public class MenuPageModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<PizzaModel> PizzaModels { get; set; }
        public MenuPageModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            PizzaModels = await _db.PizzaModel.ToListAsync();
            
        }
    }
}
