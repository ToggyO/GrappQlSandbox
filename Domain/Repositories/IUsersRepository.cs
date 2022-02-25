using Domain.Models.Users;

namespace Domain.Repositories;

public interface IUsersRepository
{
	Task<IEnumerable<User>> GetList();

	Task<User> Create(CreateUser user);
}