using FilmFeedback.Data;
using FilmFeedback.Models;
using FilmFeedback.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        [Authorize]
        public IActionResult MoreDetailed(CatalogViewModels catalog)
        {
            if (catalog?.film?.Id != -1)
            {
                catalog.film = _context.Films.Where(x => x.Id == catalog.film.Id).FirstOrDefault();
                catalog.Feedbacks = _context.Feedbacks;
            }
            else 
            {
                catalog.film.Id = -1;

                catalog.Feedbacks = _context.Feedbacks;

                if (catalog.feedback.feedback == null)
                {
                    ModelState.AddModelError("", "Поле должно быть заполнено");
                    return View(catalog);
                }
                else
                {                                    
                    var feedback = new Feedback
                    {
                        Id = _context.Feedbacks.OrderBy(x => x.Id).Last().Id + 1,
                        UserName = User?.Identity?.Name,
                        FilmName = catalog?.film?.FilmName,
                        feedback = catalog?.feedback?.feedback
                    };
                    _context.Feedbacks.Add(feedback);
                    _context.SaveChanges();
                }
                
            }
            return View(catalog);
        }

        

        private CatalogViewModels GetFilms()
		{
            var catalog = new CatalogViewModels();
            catalog.Films = _context.Films.ToList();
            return catalog;
        }
    }
}
