namespace PlatformService.Data
{
	using System;
	using System.Linq;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.Extensions.DependencyInjection;
	using Models;

	/// <summary>
	///		Prepare the database.
	///		Used only for testing purposes.
	///		Will not generate migrations.
	///		DO NOT USE IN PRODUCTION !!!
	/// </summary>
	public static class DbPreparer
	{
		public static void PrepareDatabase(IApplicationBuilder appBuilder)
		{
			// Create ServiceScope.
			using(IServiceScope serviceScope = appBuilder.ApplicationServices.CreateScope())
			{
				// Get context from ServiceScope.
				Ctx ctx = serviceScope.ServiceProvider.GetService<Ctx>();
				// Seed the database.
				SeedDatabase(ctx);
			}
		}
		
		private static void SeedDatabase(Ctx ctx)
		{
			if(ctx.Platforms.Any())
			{
				Console.WriteLine("--> Database already has data.");
			}
			else
			{
				Console.WriteLine("--> Seeding data into database.");
				
				// Add Mock data to the database.
				ctx.AddRange(
				             new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
				             new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
				             new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
				             );

				// Save changes to the database.
				ctx.SaveChanges();
				
				Console.WriteLine("--> Data seeded.");
			}
		}
	}
}