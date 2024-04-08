using ITStepRazorApp.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITStepRazorApp.Pages
{
    public class IndexModel : PageModel
    {
        public DateTime dateTime = DateTime.Now;
        public char RandomChar {  get; set; }
        

        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Random random = new Random();
            RandomChar = (char)('A' + random.Next(0, 26));
        }
    }
}
