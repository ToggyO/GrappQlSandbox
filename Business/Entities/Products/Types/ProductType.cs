using Domain.Models.Products;

using GraphQL.Types;

namespace Business.Entities.Products.Types;

public class ProductType : ObjectGraphType<Product>
{
	public ProductType()
	{
		Name = "Product";

		Field(x => x.Id).Description("Product identifier");
		Field(x => x.Name).Description("Product name");
		Field(x => x.Price).Description("Product price");
	}
}

