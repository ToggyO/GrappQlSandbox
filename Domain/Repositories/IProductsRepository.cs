using Domain.Models.Products;

namespace Domain.Repositories;

public interface IProductsRepository
{
	Task<IEnumerable<Product>> GetList();

	Task<Product> Create(CreateProduct user);
}
