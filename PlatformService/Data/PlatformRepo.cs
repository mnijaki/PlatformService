namespace PlatformService.Data
{
	using System.Collections.Generic;
	using System.Linq;
	using Models;

	public class PlatformRepo : IRepo
	{
		private readonly Ctx _ctx;
		
		public PlatformRepo(Ctx ctx)
		{
			_ctx = ctx;
		}
		
		public IEnumerable<Platform> GetPlatforms()
		{
			return _ctx.Platforms.ToList();
		}

		public Platform GetPlatform(int id)
		{
			return _ctx.Platforms.FirstOrDefault(command => command.Id == id);
		}

		public void CreatePlatform(Platform platform)
		{
			if(platform == null)
			{
				throw new System.ArgumentNullException(nameof(platform));
			}

			_ctx.Platforms.Add(platform);
		}

		public bool SaveChanges()
		{
			// Return True if 1 or more entities were changed.
			// Return False if no entities were changed.
			return (_ctx.SaveChanges() >= 0);
		}
	}
}