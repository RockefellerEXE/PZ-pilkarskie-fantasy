using FantasyApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FantasyApp.Controllers
{
	public class AccountController : Controller
	{
		UserManager<AppUser> _userManager { get; }
		SignInManager<AppUser> _signInManager { get; }
		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
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
		public async Task<IActionResult> Login()
		{
			var restult = await _signInManager.PasswordSignInAsync("TestUser", "password1", false, false);
			if (restult.Succeeded)
			{
				return RedirectToAction("Index", "Home");
			}
			else
			{
				return RedirectToAction("Privacy", "Home");
			}
		}
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
