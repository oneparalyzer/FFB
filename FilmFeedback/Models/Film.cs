using System.ComponentModel.DataAnnotations;

namespace FilmFeedback.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Введите название фильма")]
        public string? FilmName { get; set; }

        [Required]
        [Display(Name = "Введите описание фильма")]
        public string? DescriptionFilm { get; set; }

        [Required]
        [Display(Name = "Введите год релиза фильма")]
        public int YearRelease { get; set; }

        [Required]
        [Display(Name = "Введите режиссера фильма")]
        public string? Director { get; set; }

        [Required]
        [Display(Name = "Введите ссылку на аватарку фильма")]
        public string? PhotoUrl { get; set; }
    }
}
