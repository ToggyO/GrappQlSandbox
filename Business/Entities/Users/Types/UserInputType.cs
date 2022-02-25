using Domain.Models.Users;

using GraphQL.Types;

namespace Business.Entities.Users.Types;

public class UserInputType : InputObjectGraphType<CreateUser>
{
	public UserInputType()
	{
		Name = "CreateUser";

		Field<StringGraphType>("name");
		Field<StringGraphType>("email");
	}
}
