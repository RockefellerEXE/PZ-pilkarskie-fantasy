using FantasyApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FantasyApp.DAL
{
	public class UsersContext : IdentityDbContext<AppUser, AppRole, int>
	{
		public UsersContext(DbContextOptions<UsersContext> options) : base(options)
		{
		}
	}
}
