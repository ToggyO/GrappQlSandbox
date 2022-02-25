using Business.Entities.Products.Types;

using Domain.Models.Products;
using Domain.Repositories;

using GraphQL;
using GraphQL.Types;

namespace Business.Entities.Products;

public class ProductMutations : ObjectGraphType
{
	private const string Product = "product";

	public ProductMutations(IProductsRepository repository)
	{
		Field<ProductType>("createProduct",
			arguments: new QueryArguments { new QueryArgument<ProductInputType> { Name = Product } },
			resolve: context => repository.Create(context.GetArgument<CreateProduct>(Product)));
	}
}
