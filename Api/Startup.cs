using Business;

using DataLayer;

using Infrastructure;

namespace WebApplication1;

public class Startup
{
	private readonly IConfigurationRoot _configuration;

	public Startup(IConfigurationRoot configuration)
	{
		_configuration = configuration;
	}

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddDataLayer();
		services.AddInfrastructure(_configuration);
		services.AddBusinessLayer();

		services.AddControllers();
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();
	}

	public void ConfigureMiddleware(IApplicationBuilder applicationBuilder, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			applicationBuilder.UseSwagger();
			applicationBuilder.UseSwaggerUI();
		}

		// applicationBuilder.UseHttpsRedirection();
		applicationBuilder.UseAuthorization();
		applicationBuilder.UseGraphQLApi();
	}

	public void ConfigureEndpoints(IEndpointRouteBuilder routeBuilder)
	{
		routeBuilder.MapControllers();
	}
}