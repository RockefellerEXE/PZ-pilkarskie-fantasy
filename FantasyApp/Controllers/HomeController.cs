using FantasyApp.DAL;
using FantasyApp.Models;
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
		public IActionResult Aktualnosci()
        {
            return View();
        }
        public IActionResult Budowanie_zespolu(string? pozycja)
        {
            if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
            }

			IQueryable<Zawodnik> query = db.Zawodnicy.Include(z => z.Klub).Where(z => z.Pozycja == pozycja);

			var zawodnicy = query.Select(z => new Zawodnik
			{
				ZawodnikId = z.ZawodnikId,
				Nazwisko = z.Nazwisko,
				Klub = z.Klub,
				Cena = z.Cena
			}).ToList();
            return View(zawodnicy);
        }
		[HttpPost]
		[HttpPost]
		public IActionResult DodajDoDruzyny(int zawodnikId)
		{
			if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}

			// Znajdź aktualną drużynę użytkownika
			var uzytkownikId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
			var druzyna = db.Druzyny.FirstOrDefault(d => d.UzytkownikId == uzytkownikId);

			if (druzyna == null)
			{
				return BadRequest("Nie znaleziono drużyny dla użytkownika.");
			}

			// Sprawdź, czy zawodnik istnieje
			var zawodnik = db.Zawodnicy.FirstOrDefault(z => z.ZawodnikId == zawodnikId);
			if (zawodnik == null)
			{
				return BadRequest("Nie znaleziono zawodnika.");
			}

			// Sprawdź, czy zawodnik już istnieje w składzie drużyny
			if (db.SkladDruzyny.Any(sd => sd.DruzynaId == druzyna.DruzynaId && sd.ZawodnikId == zawodnikId))
			{
				return BadRequest("Zawodnik już znajduje się w składzie drużyny.");
			}

			// Dodaj zawodnika do składu drużyny
			var skladDruzyny = new SkladDruzyny
			{
				DruzynaId = druzyna.DruzynaId,
				ZawodnikId = zawodnikId
			};

			db.SkladDruzyny.Add(skladDruzyny);

			// (Opcjonalnie) Aktualizuj budżet drużyny
			if (druzyna.Budzet < zawodnik.Cena)
			{
				return BadRequest("Nie masz wystarczających środków, aby dodać tego zawodnika.");
			}
			druzyna.Budzet -= zawodnik.Cena;
			db.Druzyny.Update(druzyna);

			// Dodaj wpis do tabeli Transfery
			var transfer = new Transfer
			{
				DruzynaId = druzyna.DruzynaId,
				ZawodnikId = zawodnikId,
				TypTransferu = "Kupno" // Możesz użyć stałej lub enum, jeśli jest taka potrzeba
			};

			db.Transfery.Add(transfer);

			// Zapisz zmiany w bazie danych
			db.SaveChanges();

			return Ok("Zawodnik został dodany do drużyny i wpisany do transferów.");
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
