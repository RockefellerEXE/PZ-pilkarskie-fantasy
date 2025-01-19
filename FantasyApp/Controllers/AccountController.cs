using FantasyApp.DAL;
using FantasyApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FantasyApp.Controllers
{
	public class AccountController : Controller
	{
		UserManager<AppUser> _userManager { get; }
		SignInManager<AppUser> _signInManager { get; }

        FantasyContext db;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, FantasyContext db)
		{
			_userManager = userManager;
			_signInManager = signInManager;
            this.db = db;
		}

        [HttpPost]
        public async Task<IActionResult> Register(LoginFormUser model)
        {
            // Sprawdzamy, czy użytkownik o podanym loginie już istnieje
            var existingUser = await _userManager.FindByNameAsync(model.Username);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Użytkownik o podanej nazwie już istnieje.");
                return View("Login_Register"); // Zwracamy formularz z błędem
            }

            // Tworzymy nowego użytkownika
            var user = new AppUser
            {
                UserName = model.Username,
                Email = model.Email
            };

            // Tworzymy użytkownika z hasłem
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var newUser = await _userManager.FindByNameAsync(model.Username);
                var nowyUser = new Uzytkownik
                {
                    UzytkownikId = newUser.Id,
                    Login = newUser.UserName,
                    Punkty = 0,
                    isAdmin = false
                };
                var nowaDruzyna = new Druzyna
                {
                    UzytkownikId = nowyUser.UzytkownikId,
                    NazwaDruzyny = "Drużyna użytkownika "+ nowyUser.Login,
                    Budzet = 100,
                    PozostaleTransfrery = 2
                };
                db.Uzytkownicy.Add(nowyUser);
                db.Druzyny.Add(nowaDruzyna);
                db.SaveChanges();
                // Jeśli rejestracja się powiedzie, logujemy użytkownika
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            // Jeśli wystąpią błędy, dodajemy je do ModelState i zwracamy formularz
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View("Login_Register"); // Zwracamy formularz z błędami
        }
        public async Task<IActionResult> Register()
		{
			var user = await _userManager.FindByNameAsync("TestUser");
			if (user == null)
			{
				user = new AppUser()
				{
					UserName = "TestUser",
					Email = "testuser@test.com",
				};
				var result = await _userManager.CreateAsync(user, "password1");
			}
			return RedirectToAction("Index","Home");
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginFormUser model)
		{
            model.Email = string.Empty;

            if (ModelState.IsValid)
			{
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Nieprawidłowy login lub hasło.");
                }
            }
            return View("Login_Register");
        }
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
		public IActionResult Login_Register()
		{
			return View();
		}
        public IActionResult Ustawienia() { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login_Register");
            }

            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (result.Succeeded)
            {
                ViewData["SuccessMessage"] = "Hasło zostało pomyślnie zmienione.";
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View("Ustawienia");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeEmail(string newEmail)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login_Register");
            }

            user.Email = newEmail;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(user);
                return RedirectToAction("Ustawienia");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return RedirectToAction("Ustawienia");
        }
    }
}
