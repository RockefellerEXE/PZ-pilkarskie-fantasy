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

		public IActionResult Budowanie_zespolu(string? pozycja)
		{
			if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}

			var uzytkownikId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);

			// Pobierz drużynę użytkownika
			var druzyna = db.Druzyny.FirstOrDefault(d => d.UzytkownikId == uzytkownikId);
			if (druzyna == null)
			{
				return BadRequest("Nie znaleziono drużyny dla użytkownika.");
			}

			// Pobierz zawodników przypisanych do drużyny
			var zawodnicyWDruzynie = db.SkladDruzyny
				.Where(sd => sd.DruzynaId == druzyna.DruzynaId)
				.Include(sd => sd.Zawodnik)
				.ThenInclude(z => z.Klub)
				.Select(sd => sd.Zawodnik)
				.ToList();

			// Pobierz zawodników na podstawie wybranej pozycji (jeśli jest podana)
			IQueryable<Zawodnik> query = db.Zawodnicy.Include(z => z.Klub);
			if (!string.IsNullOrEmpty(pozycja))
			{
				query = query.Where(z => z.Pozycja == pozycja);
			}

			var zawodnicy = query.ToList();
			var budzet = druzyna.Budzet;
			ViewBag.Budzet = budzet;
			// Przekaż do widoku zawodników drużyny i dostępnych zawodników
			ViewBag.ZawodnicyWDruzynie = zawodnicyWDruzynie;
			return View(zawodnicy);
		}
		[HttpPost]
		public IActionResult DodajDoDruzyny(int zawodnikId, string formacjaString="1-4-3-3")
		{
			if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}
			Dictionary<string, int> formacja = new Dictionary<string, int>();

            List<string> klucze = new List<string> { "Bramkarz", "Obrońca", "Pomocnik", "Napastnik" };

            string[] pozycje = formacjaString.Split('-');

            for (int i = 0; i < pozycje.Length; i++)
			{
				if (int.TryParse(pozycje[i], out int liczbaZawodnikow))
				{
					formacja.Add(klucze[i], liczbaZawodnikow);
				}
			}
                // Znajdź aktualną drużynę użytkownika
                var uzytkownikId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
			var druzyna = db.Druzyny.Include(d => d.SkladDruzyny).FirstOrDefault(d => d.UzytkownikId == uzytkownikId);

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
			

            if (db.SkladDruzyny.Where(d => d.DruzynaId == druzyna.DruzynaId && d.PozycjaWDruzynie == zawodnik.Pozycja).Count() >= formacja[zawodnik.Pozycja])
            {
				return BadRequest("Na tej pozycji może być max "+ formacja[zawodnik.Pozycja] + " zawodników");

            }
                
            // Dodaj zawodnika do składu drużyny
            var skladDruzyny = new SkladDruzyny
			{
				DruzynaId = druzyna.DruzynaId,
				ZawodnikId = zawodnikId,
				PozycjaWDruzynie = zawodnik.Pozycja
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
		[HttpPost]
		public IActionResult UsunZDruzyny(int zawodnikId)
		{
			if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}

			var uzytkownikId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
			var druzyna = db.Druzyny.FirstOrDefault(d => d.UzytkownikId == uzytkownikId);

			if (druzyna == null)
			{
				return BadRequest("Nie znaleziono drużyny dla użytkownika.");
			}

			// Znajdź zawodnika w składzie drużyny
			var skladDruzyny = db.SkladDruzyny.FirstOrDefault(sd => sd.DruzynaId == druzyna.DruzynaId && sd.ZawodnikId == zawodnikId);
			if (skladDruzyny == null)
			{
				return BadRequest("Zawodnik nie znajduje się w składzie drużyny.");
			}

			// Pobierz zawodnika
			var zawodnik = db.Zawodnicy.FirstOrDefault(z => z.ZawodnikId == zawodnikId);
			if (zawodnik == null)
			{
				return BadRequest("Zawodnik nie istnieje.");
			}

			// Dodaj kwotę zawodnika do budżetu drużyny
			druzyna.Budzet += zawodnik.Cena;

			// Usuń zawodnika ze składu drużyny
			db.SkladDruzyny.Remove(skladDruzyny);

			// Dodaj transfer do tabeli Transfery (transfer "Sprzedaż")
			var transfer = new Transfer
			{
				DruzynaId = druzyna.DruzynaId,
				ZawodnikId = zawodnikId,
				TypTransferu = "Sprzedaż" // Możesz użyć stałej lub enum, jeśli jest taka potrzeba
			};
			db.Transfery.Add(transfer);

			// Zapisz zmiany w bazie danych
			db.SaveChanges();

			return Ok("Zawodnik został usunięty z drużyny, a środki zostały przywrócone do budżetu.");
		}

		public IActionResult Ranking()
		{
			var ranking = db.Uzytkownicy
				.OrderByDescending(u => u.Punkty) // Sortowanie po punktach
				.ToList();

			return View(ranking); // Przekazanie danych do widoku

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
