using Domain.Models.Products;

using GraphQL.Types;

namespace Business.Entities.Products.Types;

internal class ProductInputType : InputObjectGraphType<CreateProduct>
{
	public ProductInputType()
	{
		Name = "CreateProduct";

		Field<StringGraphType>("name");
		Field<IntGraphType>("price");
	}
}
