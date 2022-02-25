using Business.Entities.Products;
using Business.Entities.Users;

using GraphQL.Types;

namespace Business;

public class AppMutations : ObjectGraphType
{
	public AppMutations()
	{
		Field<UserMutations>("users", resolve: context => new { });
		Field<ProductMutations>("products", resolve: context => new { });
	}
}
