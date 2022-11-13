using System.ComponentModel.DataAnnotations;

namespace FilmFeedback.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? FilmName { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string? feedback { get; set; }
    }
}
