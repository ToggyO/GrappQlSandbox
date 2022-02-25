using Domain.Models.Users;

using GraphQL.Types;

namespace Business.Entities.Users.Types;

public class UserType : ObjectGraphType<User>
{
	public UserType()
	{
		Name = "User";

		Field(x => x.Id).Description("User identifier");
		Field(x => x.Name).Description("User name");
		Field(x => x.Email).Description("User email");
	}
}