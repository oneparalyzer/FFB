using FilmFeedback.Data;
using Microsoft.AspNetCore.Mvc;

namespace FilmFeedback.Controllers
{
    public class FilmsController : Controller
    {
        private readonly ILogger<FilmsController> _logger;
        private readonly ApplicationDbContext _context;
        public FilmsController(ILogger<FilmsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Catalog()
        {
            var films = _context.Films;
            return View(films);
        }
    }
}
