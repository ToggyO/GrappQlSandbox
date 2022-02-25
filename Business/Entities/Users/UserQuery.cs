using Business.Entities.Users.Types;

using Domain.Repositories;

using GraphQL.Types;

namespace Business.Entities.Users;

public class UserQuery : ObjectGraphType
{
	public UserQuery(IUsersRepository repository)
	{
		Name = "Users";

		Field<ListGraphType<UserType>>("usersList", resolve: context => repository.GetList());
	}
}