using FantasyApp.DAL;
using FantasyApp.Models;
using FantasyApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FantasyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

		FantasyContext db;

        public HomeController(ILogger<HomeController> logger, FantasyContext db)
        {
            _logger = logger;
			this.db = db;
        }

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Privacy()
		{
			return View();
		}
        public IActionResult Aktualnosci(int page = 1)
        {
            int pageSize = 10; // Liczba rekordów na stronie
            int najnowszaKolejka = db.HistoriaCen.Max(h => h.Kolejka); // Znajdź najnowszą kolejkę

            // Pobranie danych z bazy danych tylko dla najnowszej kolejki
            var zawodnicyHistoria = db.Zawodnicy
                .Include(z => z.HistoriaCen)
                .SelectMany(z => z.HistoriaCen, (zawodnik, historia) => new ZawodnikHistoriaCenViewModel
                {
                    Nazwisko = zawodnik.Nazwisko,
                    Cena = zawodnik.Cena,
                    Kolejka = historia.Kolejka,
                    CenaPrzed = historia.CenaPrzed
                })
                .Where(h => h.Kolejka == najnowszaKolejka) // Filtrowanie dla najnowszej kolejki
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Obliczanie ilości stron
            int totalCount = zawodnicyHistoria.Count(); // Liczba rekordów po filtrowaniu
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            // Przekazywanie danych do widoku
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(zawodnicyHistoria);
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
		public IActionResult Statystyki(string pozycja = "Wszyscy") // Domyślnie "Wszyscy"
		{
			ViewBag.Pozycja = pozycja; // Przekazanie aktualnie wybranej wartości do widoku

			IQueryable<Zawodnik> query = db.Zawodnicy.Include(z => z.Statystyki);

			if (pozycja != "Wszyscy" && !string.IsNullOrEmpty(pozycja))
			{
				// Filtruj po konkretnej pozycji
				query = query.Where(z => z.Pozycja == pozycja);
			}

			// Wybierz odpowiednie dane w zależności od wybranej opcji
			var zawodnicyStatystyki = query.Select(z => new ZawodnikStatystykiViewModel
			{
				Nazwisko = z.Nazwisko,
				Pozycja = z.Pozycja,
				Punkty = z.Statystyki.Sum(s => s.Punkty),
				Bramki = pozycja == "Wszyscy" ? null : (int?)z.Statystyki.Sum(s => s.Bramki),
				Asysty = pozycja == "Wszyscy" ? null : (int?)z.Statystyki.Sum(s => s.Asysty),
				ZolteKartki = pozycja == "Wszyscy" ? null : (int?)z.Statystyki.Sum(s => s.ZolteKartki),
				CzerwoneKartki = pozycja == "Wszyscy" ? null : (int?)z.Statystyki.Sum(s => s.CzerwoneKartki),
				KarneSpowodowane = pozycja == "Wszyscy" ? null : (int?)z.Statystyki.Sum(s => s.KarneSpowodowane),
				KarneWywalczone = pozycja == "Wszyscy" ? null : (int?)z.Statystyki.Sum(s => s.KarneWywalczone),
				KarneZmarnowane = pozycja == "Wszyscy" ? null : (int?)z.Statystyki.Sum(s => s.KarneZmarnowane),
				StrzalyObronione = pozycja == "Wszyscy" ? null : (int?)z.Statystyki.Sum(s => s.StrzalyObronione)
			}).ToList();

			return View(zawodnicyStatystyki);
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
