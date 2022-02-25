using Business.Entities.Users.Types;

using Domain.Models.Users;
using Domain.Repositories;

using GraphQL;
using GraphQL.Types;

namespace Business.Entities.Users;

public class UserMutations : ObjectGraphType
{
	private const string User = "user";

	public UserMutations(IUsersRepository repository)
	{
		Field<UserType>("createUser",
			arguments: new QueryArguments { new QueryArgument<UserInputType> { Name = User } },
			resolve: context => repository.Create(context.GetArgument<CreateUser>(User)));
	}
}