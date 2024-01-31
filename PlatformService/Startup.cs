using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace PlatformService
{
	using System;
	using AutoMapper;
	using Data;
	using Microsoft.EntityFrameworkCore;

	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime.
		// Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Inject Context to the container.
			services.AddDbContext<Ctx>(options => options.UseInMemoryDatabase("InMemoryDB"));
			// Inject PlatformRepo to the container as IRepo.
			services.AddScoped<IRepo, PlatformRepo>();
			// Inject AutoMapper to the container passing all assemblies as parameters.
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			// Inject Controllers to the container.
			// It allows to use Controllers in application.
			services.AddControllers();
			// Inject Swagger to the container.
			// Swagger is used for API documentation.
			services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlatformService", Version = "v1" }); });
		}

		// This method gets called by the runtime.
		// Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlatformService v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
			
			// Prepare the database.
			// Used only for testing purposes.
			// DO NOT USE IN PRODUCTION !!!
			DbPreparer.PrepareDatabase(app);
		}
	}
}