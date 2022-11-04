using SimpleApiWithDynamoDb.Contracts.Data;
using SimpleApiWithDynamoDb.Domain;
using SimpleApiWithDynamoDb.Domain.Common;

namespace SimpleApiWithDynamoDb.Mapping;

public static class DtoToDomainMapper
{
    public static User ToUser(this UserDto userDto)
    {
        return new User()
        {
            Id = UserId.From(Guid.Parse(userDto.Id)),
            FullName = FullName.From(userDto.FullName),
            EmailAddress = EmailAddress.From(userDto.Email),
            Password = Password.From(userDto.Password)
        };
    }
    
}