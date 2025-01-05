using Microsoft.AspNetCore.Identity;

namespace FantasyApp.Models
{
	public class AppUser : IdentityUser<int>
	{
		public int UzytkownikId;
	}
}
