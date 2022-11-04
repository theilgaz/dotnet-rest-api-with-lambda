using SimpleApiWithDynamoDb.Contracts.Responses;
using SimpleApiWithDynamoDb.Domain;

namespace SimpleApiWithDynamoDb.Mapping;

public static class DomainToApiContractMapper
{
    public static UserResponse ToUserResponse(this User user)
    {
        return new UserResponse
        {
            Id = user.Id.Value,
            FullName = user.FullName.Value,
            Email = user.EmailAddress.Value,
            Password= user.Password.Value
        };
    }
    
    public static GetAllUsersResponse ToGetAllUsersResponse(this IEnumerable<User> users)
    {
        return new GetAllUsersResponse
        {
            Users = users.Select(x => x.ToUserResponse()).ToList()
        };
    }
    
}