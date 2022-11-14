using FilmFeedback.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmFeedback.ViewModels
{
    public class CatalogViewModels
    {
        public List<Film>? Films { get; set; }
        public string? FilmName { get; set; }
        public Film? film { get; set; }
        public DbSet<Feedback>? Feedbacks { get; set; }

        public Feedback? feedback { get; set; }
    }
}
