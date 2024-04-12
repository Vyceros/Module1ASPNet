using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ITStepRazorApp.Data;

namespace ITStepRazorApp.Pages
{
    public class InfoModel : PageModel
    {
        [BindProperty]
        public KhachapuriModel khachapuri { get; set; }
        public float khachapuriPrice { get; set; }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            khachapuriPrice = khachapuri.BasePrice;

            if (khachapuri.Large) khachapuriPrice += 10;
            if(khachapuri.Medium) khachapuriPrice += 8;


            return RedirectToPage("Index", khachapuri.KhachapuriName, khachapuriPrice);
        }
    }
}
