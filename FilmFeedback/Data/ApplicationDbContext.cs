using FilmFeedback.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilmFeedback.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Film> Films { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
