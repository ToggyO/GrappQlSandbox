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
			.AddGraphTypes(typeof(DependencyInjection), ServiceLifetime.Scoped)
			.AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User });

		return services;
	}

	public static IApplicationBuilder UseGraphQLApi(this IApplicationBuilder app)
	{
		// app.UseGraphQLAuthentication();

		app.UseGraphQL<AppSchema>();

		app.UseGraphQLPlayground(new PlaygroundOptions());

		return app;
	}

	// public static IApplicationBuilder UseGraphQLAuthentication(this IApplicationBuilder app,string path = "/graphql")
	// 	=> app.UseWhen(
	// 		context => context.Request.Path.StartsWithSegments(path, out var remaining) && string.IsNullOrEmpty(remaining),
	// 		b => b.UseMiddleware<GraphQLAuthenticationMiddleware>());
}