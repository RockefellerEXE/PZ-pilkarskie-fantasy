using FantasyApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FantasyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Privacy()
		{
			return View();
		}
		public IActionResult Aktualnosci()
        {
            return View();
        }
        public IActionResult Budowanie_zespolu()
        {
            if (!User.Identity.IsAuthenticated)
			{ 
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
		public IActionResult Ranking()
		{
			return View();
		}
		public IActionResult Statystyki()
		{
			return View();
		}
		public IActionResult Terminarz()
		{
			return View();
		}
		public IActionResult Zasady_faq()
		{
			return View();
		}
		public IActionResult Kontakt()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
