namespace PlatformService.MappingProfiles
{
	using AutoMapper;
	using Dtos;
	using Models;

	public class PlatformsProfile : Profile
	{
		public PlatformsProfile()
		{
			// Source -> Target.
			CreateMap<Platform, PlatformReadDto>();
			CreateMap<PlatformCreateDto, Platform>();
		}
	}
}