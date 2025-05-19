using System.ComponentModel.DataAnnotations;
namespace NotifyX.Models

{
    public class LoginViewModel
    {
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        
        [Display(Name = "Senha")]
        public string Password { get; set; }

        
        public bool RememberMe { get; set; }
    }
}
