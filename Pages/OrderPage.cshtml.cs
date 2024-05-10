using ITStepRazorApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITStepRazorApp.Pages
{
    public class OrderPageModel : PageModel
    {
        public PizzaModel Pizza { get; set; }
        public float PizzaPrice { get; set; }
        public void OnGet()
        {
        }
    }
}
