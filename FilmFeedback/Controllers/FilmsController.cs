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

        [HttpGet]
        public IActionResult MoreDetailed(int filmId)
        {
            var moreDetailedViewModel = new MoreDetailedViewModel();
            moreDetailedViewModel.film = _context.Films.Where(x => x.Id == filmId).FirstOrDefault();
            moreDetailedViewModel.Feedbacks = _context.Feedbacks;
            return View(moreDetailedViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult MoreDetailed(MoreDetailedViewModel moreDetailedViewModel)
        {
            moreDetailedViewModel.Feedbacks = _context.Feedbacks;
            if (ModelState.IsValid)
            {
                var feedback = new Feedback();
                feedback.feedback = moreDetailedViewModel?.feedback?.feedback;
                feedback.UserName = User?.Identity?.Name;
                feedback.Id = _context.Feedbacks.OrderBy(x => x.Id).Last().Id + 1;
                feedback.FilmName = moreDetailedViewModel?.film?.FilmName;
                Console.WriteLine(feedback.feedback + " " + feedback.UserName + " " + feedback.Id + " " + feedback.FilmName);
                _context.Feedbacks.Add(feedback);
                _context.SaveChanges();
            }
            ModelState.Clear();
            return View(moreDetailedViewModel);
        }

        private CatalogViewModels GetFilms()
		{
            var catalog = new CatalogViewModels();
            catalog.Films = _context.Films.ToList();
            return catalog;
        }
    }
}
