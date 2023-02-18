using StormGames.Domain.Entities;

namespace StormGames.Infra.Contracts;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<User> GetUserById(Guid id);
    public Task<User> GetUserByEmail(string email);
    public Task<IList<User>> GetAllActiveUsers();
}