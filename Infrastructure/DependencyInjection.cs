using Business.Contracts;

using Infrastructure.Factories;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services,
		IConfiguration configuration)
	{
		services.AddScoped<ITokensFactory, JwtTokensFactory>();

		return services;
	}
}