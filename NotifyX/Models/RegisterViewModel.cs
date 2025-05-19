using System.ComponentModel.DataAnnotations;

namespace NotifyX.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "As senhas não coincidem")]
        public string ConfirmPassword { get; set; }
    }
}
