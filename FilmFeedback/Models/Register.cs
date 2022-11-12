using System.ComponentModel.DataAnnotations;

namespace FilmFeedback.Models
{
    public class Register
    {
        [Required]
        [Display(Name = "Имя")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string? Surname { get; set; }

        [Required]
        [Display(Name = "Логин")]
        public string? Login { get; set; }

        [Required]
        [Display(Name = "Адрес электронной почты")]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Подтвердить пароль")]
        public string? PasswordConfirm { get; set; }
    }
}
