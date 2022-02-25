using DataLayer.Repositories;

using Domain.Repositories;

using Microsoft.Extensions.DependencyInjection;

namespace DataLayer;

public static class DependencyInjection
{
	public static IServiceCollection AddDataLayer(this IServiceCollection services)
	{
		services.AddSingleton<IUsersRepository, UsersRepository>();
		services.AddSingleton<IProductsRepository, ProductsRepository>();

		return services;
	}
}