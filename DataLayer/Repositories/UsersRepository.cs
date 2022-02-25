using Domain.Models.Users;
using Domain.Repositories;

namespace DataLayer.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly List<User> _users = new();

    public UsersRepository()
    {
        if (_users.Count == 0)
        {
            var users = new[]
            {
                new User { Id = 1, Name = "Oleg", Email = "asd@asd.com" },
                new User { Id = 2, Name = "Azamat", Email = "kek@shpek.com" },
                new User { Id = 3, Name = "Denis", Email = "qwe@qwe.com" },
                new User { Id = 3, Name = "Sveta", Email = "eldik@n.com" }
            };
            _users.AddRange(users);
        }
    }

    public async Task<IEnumerable<User>> GetList() => await Task.FromResult(_users);

    public Task<User> Create(CreateUser user)
    {
        var newUser = new User
        {
	        Id = _users.Max(x => x.Id) + 1,
			Name = user.Name,
			Email = user.Email
        };
        _users.Add(newUser);
        return Task.FromResult(newUser);
    }
}