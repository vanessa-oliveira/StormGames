using StormGames.Application.Models;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Queries;

public class UserQueries : IUserQueries
{
    private readonly IUserRepository _userRepository;

    public UserQueries(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<IList<UserResponse>> ListAllActiveUsers()
    {
        var users = await _userRepository.GetAllActiveUsers();
        IList<UserResponse> usersResponse = new List<UserResponse>();
        foreach (var user in users)
        {
            usersResponse.Add(new UserResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth
            });
        }

        return usersResponse;
    }

    public Task<LoginUserResponse> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }
}