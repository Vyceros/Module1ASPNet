using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ITStepRazorApp.Data;

namespace ITStepRazorApp.Pages
{
    public class CountriesModel : PageModel
    {
        public List<Countries> seedCountries = new List<Countries>()
        {
            new Countries(){Country="Georgia",City="Tbilisi",Continent="Europe",Population=3719911},
            new Countries(){Country="Poland",City="Warsaw",Continent="Europe",Population=40398475},
            new Countries(){Country="Japan",City="Tokyo",Continent="Asia",Population=122780836},
            new Countries(){Country="USA",City="Washington DC",Continent="North America",Population=341397313},
        };
        public void OnGet()
        {
        }
    }
}
