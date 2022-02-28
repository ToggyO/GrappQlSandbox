using Business.Entities.Users.Types;

using Common.Models.Response;

using Domain.Models.Users;
using Domain.Repositories;

using GraphQL.Types;

namespace Business.Entities.Users;

public class UserQuery : ObjectGraphType
{
	public UserQuery(IUsersRepository repository)
	{
		Name = "Users";

		//FieldAsync<ListGraphType<UserType>>("usersList",
		//	resolve: async context => new Response<IEnumerable<User>> { Data = await repository.GetList() });
		FieldAsync<ListGraphType<UserType>>("usersList",
			resolve: async context => await repository.GetList());
	}
}