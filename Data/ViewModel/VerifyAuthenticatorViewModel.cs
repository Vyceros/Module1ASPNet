using System.ComponentModel.DataAnnotations;

namespace ITStepRazorApp.Data.ViewModel
{
    public class VerifyAuthenticatorViewModel
    {
        [Required]
        public string? Code {  get; set; }
        public string? ReturnUrl {  get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe {  get; set; }
    }
}
