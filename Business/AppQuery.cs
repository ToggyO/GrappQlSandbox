using Business.Entities.Products;
using Business.Entities.Users;

using GraphQL.Types;

namespace Business;

public class AppQuery : ObjectGraphType
{
	public AppQuery()
	{
		Field<UserQuery>("users", resolve: context => new { });
		Field<ProductQuery>("products", resolve: context => new { });
	}
}
