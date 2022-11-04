using SimpleApiWithDynamoDb.Contracts.Requests;
using SimpleApiWithDynamoDb.Domain;
using SimpleApiWithDynamoDb.Domain.Common;

namespace SimpleApiWithDynamoDb.Mapping;

public static class ApiContractToDomainMapper
{
    public static User ToUser(this CreateUserRequest request)
    {
        return new User
        {
            Id = UserId.From(Guid.NewGuid()),
            FullName = FullName.From(request.FullName),
            EmailAddress = EmailAddress.From(request.Email),
            Password = Password.From(request.Password)
        };
    }
    
    public static User ToUser(this UpdateUserRequest request)
    {
        return new User
        {
            Id = UserId.From(request.Id),
            FullName = FullName.From(request.FullName),
            EmailAddress = EmailAddress.From(request.Email),
            Password = Password.From(request.Password)
        };
    }
}