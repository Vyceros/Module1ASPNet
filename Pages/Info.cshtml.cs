using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ITStepRazorApp.Data;

namespace ITStepRazorApp.Pages
{
    public class InfoModel : PageModel
    {
        public List<KhachapuriModel> khachapuris = new List<KhachapuriModel>()
        {
            new KhachapuriModel(){ImageTitle = "Khachapuri",KhachapuriName = "Imeruli",Large = true,BasePrice = 12,FinalPrice = 20 },
            new KhachapuriModel(){ImageTitle = "Khachapuri",KhachapuriName = "Acharuli",Medium = true,BasePrice = 12,FinalPrice = 23 },  
        };
        public void OnGet()
        {
        }
    }
}
