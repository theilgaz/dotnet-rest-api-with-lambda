using SimpleApiWithDynamoDb.Contracts.Data;

namespace SimpleApiWithDynamoDb.Repositories;

public interface IUserRepository
{
    Task<bool> CreateAsync(UserDto user);
    Task<UserDto?> GetAsync(Guid id);
    Task<bool> UpdateAsync(UserDto user);
    Task<bool> DeleteAsync(Guid id);
}