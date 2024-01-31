namespace PlatformService.Controllers
{
	using System.Collections.Generic;
	using AutoMapper;
	using Data;
	using Dtos;
	using Microsoft.AspNetCore.Mvc;
	using Models;

	/// <summary>
	///   "ControllerBase" is a base class for WEB API without view support.
	///	  For MVC projects, with view support, use "Controller" instead.
	///	  "[ApiController]":
	///		* Is a built-in attribute that does automatic model validation.
	///	    * Implements Automatic HTTP 400 Responses when the request data cannot be parsed or validated.
	///		* Binds source for parameters (informs how to resolve request parameters).
	///		* Allows for Attribute Routing.
	///		* Handle errors in a standardized way (gives appropriate status code and details).
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class PlatformsController : ControllerBase
	{
		private readonly IRepo _repo;
		private readonly IMapper _mapper;

		public PlatformsController(IRepo repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}
		
		[HttpGet]
		public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
		{
			IEnumerable<Platform> platforms = _repo.GetPlatforms();
			IEnumerable<PlatformReadDto> platformsReadDto = _mapper.Map<IEnumerable<PlatformReadDto>>(platforms);
			
			return Ok(platformsReadDto);
		}
		
		[HttpGet("{id}", Name = "GetPlatform")]
		public ActionResult<PlatformReadDto> GetPlatform(int id)
		{
			Platform platform = _repo.GetPlatform(id);
			if(platform == null)
			{
				return NotFound();
			}

			PlatformReadDto platformReadDto = _mapper.Map<PlatformReadDto>(platform);
			
			return Ok(platformReadDto);
		}
	}
}