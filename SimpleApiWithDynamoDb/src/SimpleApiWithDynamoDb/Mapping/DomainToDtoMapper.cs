using SimpleApiWithDynamoDb.Contracts.Data;
using SimpleApiWithDynamoDb.Domain;

namespace SimpleApiWithDynamoDb.Mapping;

public static class DomainToDtoMapper
{
    public static UserDto ToUserDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id.Value.ToString(),
            FullName = user.FullName.Value,
            Email = user.EmailAddress.Value,
            Password = user.Password.Value
        };
    }
}