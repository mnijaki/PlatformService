namespace PlatformService.Data
{
	using System.Collections.Generic;
	using Models;

	public interface IRepo
	{
		IEnumerable<Platform> GetPlatforms();
		
		Platform GetPlatform(int id);
		
		void CreatePlatform(Platform platform);

		bool SaveChanges();
	}
}