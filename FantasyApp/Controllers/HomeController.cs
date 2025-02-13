﻿using FantasyApp.DAL;
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
			int pageSize = 6; // Liczba rekordów na stronie
			int najnowszaKolejka = db.HistoriaCen.Max(h => h.Kolejka); // Znajdź najnowszą kolejkę

			// Pobranie danych z bazy danych tylko dla najnowszej kolejki
			var query = db.Zawodnicy
				.Include(z => z.HistoriaCen)
				.SelectMany(z => z.HistoriaCen, (zawodnik, historia) => new ZawodnikHistoriaCenViewModel
				{
					Nazwisko = zawodnik.Nazwisko,
					Cena = zawodnik.Cena,
					Kolejka = historia.Kolejka,
					CenaPrzed = historia.CenaPrzed
				})
				.Where(h => h.Kolejka == najnowszaKolejka); // Filtrowanie dla najnowszej kolejki

			// Obliczanie całkowitej liczby rekordów
			int totalCount = query.Count(); // Liczba rekordów po filtrowaniu

			// Obliczanie liczby stron
			int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

			// Sprawdzanie, czy strona jest w zakresie
			page = Math.Max(1, Math.Min(page, totalPages));

			// Pobranie danych tylko dla aktualnej strony
			var currentPageData = query
				.Skip((page - 1) * pageSize) // Przesuwamy o (page - 1) * pageSize
				.Take(pageSize)              // Pobieramy tylko pageSize rekordów
				.ToList();                   // Ładujemy tylko dane dla tej strony

			// Przekazywanie danych do widoku
			ViewBag.CurrentPage = page;
			ViewBag.TotalPages = totalPages;
			ViewBag.NajnowszaKolejka = najnowszaKolejka;

			return View(currentPageData);
		}



		public IActionResult Budowanie_zespolu(string pozycja = "Wszyscy")
		{
			ViewBag.Pozycja = pozycja;
			if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}
            if (TempData["ErrorMessage"] != null)
            {
				ModelState.AddModelError(string.Empty, TempData["ErrorMessage"].ToString());
            }
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            var uzytkownikId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);

			// Pobierz drużynę użytkownika
			var druzyna = db.Druzyny.FirstOrDefault(d => d.UzytkownikId == uzytkownikId);
			if (druzyna == null)
			{
                TempData["ErrorMessage"] = "Nie znaleziono drużyny dla użytkownika.";
                return RedirectToAction("Budowanie_zespolu",pozycja);
			}

			// Pobierz zawodników przypisanych do drużyny wraz z ich pozycją w drużynie
			var zawodnicyWDruzynie = db.SkladDruzyny
				.Where(sd => sd.DruzynaId == druzyna.DruzynaId)
				.Include(sd => sd.Zawodnik)
				.ThenInclude(z => z.Klub)
				.Select(sd => new ZawodnikWDruzynieViewModel
				{
					ZawodnikId = sd.Zawodnik.ZawodnikId,
					Nazwisko = sd.Zawodnik.Nazwisko,
					KlubNazwa = sd.Zawodnik.Klub.Nazwa,
					PozycjaWDruzynie = sd.PozycjaWDruzynie,
					Punkty = sd.Zawodnik.Statystyki.Sum(s => s.Punkty),
					CenaZawodnika = sd.Zawodnik.Cena,
                })
				.ToList();

			// Pobierz zawodników na podstawie wybranej pozycji (jeśli jest podana)
			IQueryable<Zawodnik> query = db.Zawodnicy.Include(z => z.Klub);
			if (!string.IsNullOrEmpty(pozycja) && !pozycja.Equals("Wszyscy"))
			{
				query = query.Where(z => z.Pozycja == pozycja);
			}

			var zawodnicy = query.ToList();

			// Przekaż dane do widoku
			ViewBag.ZawodnicyWDruzynie = zawodnicyWDruzynie;
			ViewBag.Budzet = druzyna.Budzet;

			return View(zawodnicy);
		}

		[HttpPost]
		public IActionResult DodajDoDruzyny(int zawodnikId, string pozycja, string formacjaString="1-4-3-3", bool czytransfer = true)
		{
			czytransfer = db.CzyTransfer.Select(z => z.czyTransfer).FirstOrDefault();

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
			if (czytransfer)
			{
                TempData["ErrorMessage"] = "Transfery zablokowane.";
                return RedirectToAction("Budowanie_zespolu", new { pozycja });
            }
			if (druzyna == null)
			{
                TempData["ErrorMessage"] = "Nie znaleziono drużyny dla użytkownika.";
                return RedirectToAction("Budowanie_zespolu", new { pozycja });
            }
			// Sprawdź, czy zawodnik istnieje
			var zawodnik = db.Zawodnicy.FirstOrDefault(z => z.ZawodnikId == zawodnikId);
			if (zawodnik == null)
			{
                TempData["ErrorMessage"] = "Nie znaleziono zawodnika.";
                return RedirectToAction("Budowanie_zespolu", new { pozycja });
			}

			// Sprawdź, czy zawodnik już istnieje w składzie drużyny
			if (db.SkladDruzyny.Any(sd => sd.DruzynaId == druzyna.DruzynaId && sd.ZawodnikId == zawodnikId))
			{
                
                TempData["ErrorMessage"] = "Zawodnik już znajduje się w składzie drużyny.";
                return RedirectToAction("Budowanie_zespolu",new { pozycja });
			}
			

            if (db.SkladDruzyny.Where(d => d.DruzynaId == druzyna.DruzynaId && d.PozycjaWDruzynie == zawodnik.Pozycja).Count() >= formacja[zawodnik.Pozycja])
            {
                string zawodnikFormString = formacja[zawodnik.Pozycja] == 1 ? "zawodnik" : "zawodników";
                TempData["ErrorMessage"] = "Na tej pozycji może być max "+ formacja[zawodnik.Pozycja] + " "+ zawodnikFormString;
                return RedirectToAction("Budowanie_zespolu",new { pozycja });

            }
			if (czytransfer && druzyna.PozostaleTransfrery == 0)
			{
                TempData["ErrorMessage"] = "Nie masz więcej transferów do wykorzystania";
                return RedirectToAction("Budowanie_zespolu", new { pozycja });
			}
                
            // Dodaj zawodnika do składu drużyny
            var skladDruzyny = new SkladDruzyny
			{
				DruzynaId = druzyna.DruzynaId,
				ZawodnikId = zawodnikId,
				PozycjaWDruzynie = zawodnik.Pozycja
				
			};
			
			db.SkladDruzyny.Add(skladDruzyny);

			if (druzyna.Budzet < zawodnik.Cena)
			{
                TempData["ErrorMessage"] = "Nie masz wystarczających środków, aby dodać tego zawodnika.";
                return RedirectToAction("Budowanie_zespolu", new { pozycja });
			}
			if (czytransfer)
			{
				druzyna.PozostaleTransfrery -= 1;
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
            TempData["SuccessMessage"] = "Zawodnik został dodany do drużyny i wpisany do transferów.";
            return RedirectToAction("Budowanie_zespolu", new { pozycja });
		}

        // Akcja w kontrolerze do dodawania zawodników na ławkę
        public IActionResult DodajNaLawke(int zawodnikId, string pozycja, bool czytransfer = false)
        {
			czytransfer = db.CzyTransfer.Select(z => z.czyTransfer).FirstOrDefault();

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
			if (czytransfer)
			{
                TempData["ErrorMessage"] = "Transfery zablokowane.";
                return RedirectToAction("Budowanie_zespolu", new { pozycja });
            }
            // Znajdź aktualną drużynę użytkownika
            var uzytkownikId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
            var druzyna = db.Druzyny.Include(d => d.SkladDruzyny).FirstOrDefault(d => d.UzytkownikId == uzytkownikId);

            if (druzyna == null)
            {
                TempData["ErrorMessage"] = "Nie znaleziono drużyny dla użytkownika.";
                return RedirectToAction("Budowanie_zespolu", new { pozycja });
            }

            // Sprawdź, czy zawodnik istnieje
            var zawodnik = db.Zawodnicy.FirstOrDefault(z => z.ZawodnikId == zawodnikId);
            if (zawodnik == null)
            {
                TempData["ErrorMessage"] = "Nie znaleziono zawodnika.";
                return RedirectToAction("Budowanie_zespolu", new { pozycja });
            }

            // Sprawdź, czy zawodnik już jest na ławce lub w drużynie
            if (db.SkladDruzyny.Any(sd => sd.DruzynaId == druzyna.DruzynaId && sd.ZawodnikId == zawodnikId))
            {
                TempData["ErrorMessage"] = "Zawodnik już znajduje się w drużynie lub na ławce.";
				return RedirectToAction("Budowanie_zespolu", new { pozycja });
            }

            // Sprawdź, czy liczba zawodników na ławce nie przekracza 5
            if (db.SkladDruzyny.Count(sd => sd.DruzynaId == druzyna.DruzynaId && sd.PozycjaWDruzynie == "Ławka") >= 5)
            {
                TempData["ErrorMessage"] = "Na ławce rezerwowych może być maksymalnie 5 zawodników.";
                return RedirectToAction("Budowanie_zespolu", new { pozycja });
            }

            // Dodaj zawodnika na ławkę rezerwowych
            var skladLawki = new SkladDruzyny
            {
                DruzynaId = druzyna.DruzynaId,
                ZawodnikId = zawodnikId,
                PozycjaWDruzynie = "Ławka"
            };

            db.SkladDruzyny.Add(skladLawki);
            if (druzyna.Budzet < zawodnik.Cena)
            {
                TempData["ErrorMessage"] = "Nie masz wystarczających środków, aby dodać tego zawodnika.";
                return RedirectToAction("Budowanie_zespolu", new { pozycja });
            }
            if (czytransfer)
            {
                druzyna.PozostaleTransfrery -= 1;
            }
            druzyna.Budzet -= zawodnik.Cena;
            db.Druzyny.Update(druzyna);

            // Dodaj wpis do tabeli Transfery
            var transfer = new Transfer
            {
                DruzynaId = druzyna.DruzynaId,
                ZawodnikId = zawodnikId,
                TypTransferu = "Kupno - Ławka" // Możesz użyć stałej lub enum, jeśli jest taka potrzeba
            };

            db.Transfery.Add(transfer);
            // Zapisz zmiany w bazie danych
            db.SaveChanges();

            TempData["SuccessMessage"] = "Zawodnik został dodany na ławkę rezerwowych.";
            return RedirectToAction("Budowanie_zespolu", new {pozycja});
        }
        [HttpPost]
		public IActionResult UsunZDruzyny(int zawodnikId, string pozycja)
		{
            bool czytransfer = db.CzyTransfer.Select(z => z.czyTransfer).FirstOrDefault();

            if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}
			if (czytransfer)
			{
				TempData["ErrorMessage"] = "Transfery zablokowane.";
                return RedirectToAction("Budowanie_zespolu", new { pozycja });
			}
			var uzytkownikId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
			var druzyna = db.Druzyny.FirstOrDefault(d => d.UzytkownikId == uzytkownikId);

			if (druzyna == null)
			{
                TempData["ErrorMessage"] = "Nie znaleziono drużyny dla użytkownika.";
                return RedirectToAction("Budowanie_zespolu", new { pozycja });
			}

			// Znajdź zawodnika w składzie drużyny
			var skladDruzyny = db.SkladDruzyny.FirstOrDefault(sd => sd.DruzynaId == druzyna.DruzynaId && sd.ZawodnikId == zawodnikId);
			if (skladDruzyny == null)
			{
                TempData["ErrorMessage"] = "Zawodnik nie znajduje się w składzie drużyny.";
                return RedirectToAction("Budowanie_zespolu", new { pozycja });
			}

			// Pobierz zawodnika
			var zawodnik = db.Zawodnicy.FirstOrDefault(z => z.ZawodnikId == zawodnikId);
			if (zawodnik == null)
			{
                TempData["ErrorMessage"] = "Zawodnik nie istnieje.";
                return RedirectToAction("Budowanie_zespolu", new { pozycja });
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
            TempData["SuccessMessage"] = "Zawodnik został usunięty z drużyny, a środki zostały przywrócone do budżetu.";
            return RedirectToAction("Budowanie_zespolu", new { pozycja });
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
				Klub = z.Klub.Nazwa,
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
        [HttpPost]
        public IActionResult PodliczZawodnikow()
		{
            IQueryable<StatystykiZawodnikow> query = db.StatystykiZawodnikow.Include(z => z.Zawodnik);
			var zawodnicyStatystyki = query.Select(z => new StatystykiZawodnikow
			{

                StatystykiZawodnikowId = z.StatystykiZawodnikowId,
				ZawodnikId = z.ZawodnikId,
				Bramki = z.Bramki,
				Asysty = z.Asysty,
				ZolteKartki = z.ZolteKartki,
				CzerwoneKartki = z.CzerwoneKartki,
				KarneSpowodowane = z.KarneSpowodowane,
				KarneWywalczone = z.KarneWywalczone,
				KarneZmarnowane =z.KarneZmarnowane,
				StrzalyObronione = z.StrzalyObronione,
				Punkty = 0
			}).ToList();

            foreach (var item in zawodnicyStatystyki)
            {
				string pozycja = db.Zawodnicy.Where(z => z.ZawodnikId == item.ZawodnikId).Select(z => z.Pozycja).ToString();
				item.Punkty = item.Bramki * (pozycja == "Napastnik" ? 6 : 5) +
				item.Asysty * (pozycja == "Pomocnik" ? 5 : 4) +
				item.ZolteKartki * -1 +
				item.CzerwoneKartki * -4 +
				item.KarneSpowodowane * -2 +
				item.KarneWywalczone * 3 +
				item.KarneZmarnowane * -3 +
				item.StrzalyObronione/2;
            }
			db.StatystykiZawodnikow.UpdateRange(zawodnicyStatystyki);
			db.SaveChanges();
            return RedirectToAction("Statystyki", "Home");
		}
        [HttpPost]
        public IActionResult PodliczGraczy()
		{
            IQueryable<Uzytkownik> query = db.Uzytkownicy;
			var users = query.Select(u => new Uzytkownik
			{
				UzytkownikId = u.UzytkownikId,
				Login = u.Login,
				Punkty = u.Punkty,
				isAdmin = u.isAdmin
			});
            foreach (var user in users)
            {
				IQueryable<SkladDruzyny> druzynaQuery = db.SkladDruzyny.Where(z => z.DruzynaId == user.UzytkownikId);
				var druzyna = druzynaQuery.Select(d => new SkladDruzyny
				{
					DruzynaId = d.DruzynaId,
					ZawodnikId = d.ZawodnikId,
					PozycjaWDruzynie = d.PozycjaWDruzynie
				});
                foreach (var item in druzyna)
                {
					int punkt = db.StatystykiZawodnikow.Where(s => s.ZawodnikId == item.ZawodnikId).Sum(s=>s.Punkty);
					user.Punkty += (item.PozycjaWDruzynie != "Ławka" ? punkt : punkt / 2);
                }
				db.Uzytkownicy.Update(user);
            }
			db.SaveChanges();
            


            return RedirectToAction("Ranking", "Home");

        }

        public IActionResult Lock()
        {
            var query = db.CzyTransfer;
			var czyTransfer = query.Select(t => new CzyTransfer
			{
				CzyTransferId = 1,
				czyTransfer = true
			});

            db.CzyTransfer.UpdateRange(czyTransfer);
            db.SaveChanges();

            return RedirectToAction("Budowanie_zespolu", "Home", new {pozycja = "Wszyscy"});

        }
        public IActionResult Unlock()
        {
            var query = db.CzyTransfer;
            var czyTransfer = query.Select(t => new CzyTransfer
            {
                CzyTransferId = 1,
                czyTransfer = false
            });

            db.CzyTransfer.UpdateRange(czyTransfer);
            db.SaveChanges();

			return RedirectToAction("Budowanie_zespolu", "Home", new { pozycja = "Wszyscy" });

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
