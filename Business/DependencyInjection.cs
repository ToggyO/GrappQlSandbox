using GraphQL.Server;
using GraphQL.Server.Ui.Playground;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public static class DependencyInjection
{
	public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
	{
		services.AddScoped<AppSchema>();

		services.AddGraphQL(opt => opt.EnableMetrics = false)
			.AddSystemTextJson()
			.AddGraphTypes(typeof(DependencyInjection), ServiceLifetime.Scoped);

		return services;
	}

	public static IApplicationBuilder UseGraphQLApi(this IApplicationBuilder app)
	{
		app.UseGraphQL<AppSchema>();

		app.UseGraphQLPlayground(new PlaygroundOptions());

		return app;
	}
}