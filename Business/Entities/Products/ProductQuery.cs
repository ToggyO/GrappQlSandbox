using Business.Entities.Products.Types;

using Domain.Repositories;

using GraphQL.Types;

namespace Business.Entities.Products;

public class ProductQuery : ObjectGraphType
{
	public ProductQuery(IProductsRepository repository)
	{
		Name = "Products";

		Field<ListGraphType<ProductType>>("productsList", resolve: context => repository.GetList());
	}
}

