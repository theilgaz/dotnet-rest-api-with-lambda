using FluentValidation;
using FluentValidation.Results;
using SimpleApiWithDynamoDb.Domain;
using SimpleApiWithDynamoDb.Mapping;
using SimpleApiWithDynamoDb.Repositories;

namespace SimpleApiWithDynamoDb.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<bool> CreateAsync(User user)
    {
        var existingUser = await _userRepository.GetAsync(user.Id.Value);
        if (existingUser != null)
        {
            var message = $"User with id {user.Id.Value} already exists";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(User), message)
            });
        }

        var userDto = user.ToUserDto();
        return await _userRepository.CreateAsync(userDto);
    }

    public async Task<User?> GetAsync(Guid id)
    {
        var userDto = await _userRepository.GetAsync(id);
        return userDto?.ToUser();
    }

    public async Task<bool> UpdateAsync(User user)
    {
        var userDto = user.ToUserDto();
        return await _userRepository.UpdateAsync(userDto);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _userRepository.DeleteAsync(id);
    }
}