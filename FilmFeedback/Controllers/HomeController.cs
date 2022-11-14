using FilmFeedback.Data;
using FilmFeedback.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FilmFeedback.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}