using FilmFeedback.Data;
using FilmFeedback.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmFeedback.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly ApplicationDbContext _context;
        public AdminController(ILogger<AdminController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddFilm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFilm(Film film)
        {
            if (ModelState.IsValid)
            {
                _context.Films.AddAsync(film);
                _context.SaveChangesAsync();
            }
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public IActionResult DeleteFilm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteFilm(Film film)
        {
            if (ModelState.IsValid)
            {               
                var DeleteFilm = _context.Films.Where(x => x.FilmName == film.FilmName).FirstOrDefault();
                if (DeleteFilm != null)
                {
                    _context.Films.Remove(DeleteFilm);
                    _context.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError("", "Такого фильма нет");
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
