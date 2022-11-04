using SimpleApiWithDynamoDb.Domain;

namespace SimpleApiWithDynamoDb.Services;

public interface IUserService
{
    Task<bool> CreateAsync(User user);
    Task<User?> GetAsync(Guid id);
    Task<bool> UpdateAsync(User user);
    Task<bool> DeleteAsync(Guid id);
}