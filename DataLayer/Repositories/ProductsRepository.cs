using Domain.Models.Products;
using Domain.Repositories;

namespace DataLayer.Repositories;

public class ProductsRepository : IProductsRepository
{
	private readonly List<Product> _products = new();

	public ProductsRepository()
	{
		if (_products.Count == 0)
		{
			var users = new[]
			{
				new Product { Id = 1, Name = "TV set" },
				new Product { Id = 2, Name = "Microwave" },
				new Product { Id = 3, Name = "Bed" },
			};
			_products.AddRange(users);
		}
	}

	public Task<IEnumerable<Product>> GetList() => Task.FromResult((IEnumerable<Product>)_products);

	public Task<Product> Create(CreateProduct product)
	{
		var newProduct = new Product
		{
			Id = _products.Max(x => x.Id) + 1,
			Name = product.Name,
			Price = product.Price
		};
		_products.Add(newProduct);
		return Task.FromResult(newProduct);
	}
}

