using FilmFeedback.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FilmFeedback.ViewModels
{
    public class MoreDetailedViewModel
    {
        public Film? film { get; set; }
        public DbSet<Feedback>? Feedbacks { get; set; }

        public Feedback? feedback { get; set; }
    }
}
