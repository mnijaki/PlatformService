namespace PlatformService.Data
{
	using Microsoft.EntityFrameworkCore;
	using Models;

	public class Ctx : DbContext
	{
		public DbSet<Platform> Platforms { get; set; }
		
		public Ctx(DbContextOptions<Ctx> options) : base(options)
		{
		}
	}
}