using System.ComponentModel.DataAnnotations;

namespace FilmFeedback.Models
{
    public class Login
    {
        [Required]
        [Display(Name = "Адрес электронной почты")]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
