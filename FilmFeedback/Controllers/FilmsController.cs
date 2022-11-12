using FilmFeedback.Data;
using FilmFeedback.Models;
using FilmFeedback.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var catalogFilm = GetFilms();
            return View(catalogFilm);
        }

        [HttpPost]
        public IActionResult Catalog(CatalogViewModels catalog)
        {
            var filmName = catalog.FilmName;
            if (filmName != null)
			{
                var films = _context.Films.Where(x => x.FilmName.ToLower().Contains(filmName.ToLower())).ToList();
                catalog.Films = films;
                return View(catalog);
			}
            var catalogFilm = GetFilms();
            return View(catalogFilm);
        }

        private CatalogViewModels GetFilms()
		{
            var catalog = new CatalogViewModels();
            catalog.Films = _context.Films.ToList();
            return catalog;
        }
    }
}
