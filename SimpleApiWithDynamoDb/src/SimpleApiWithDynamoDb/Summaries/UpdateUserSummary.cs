using FastEndpoints;
using SimpleApiWithDynamoDb.Contracts.Responses;
using SimpleApiWithDynamoDb.Endpoints;

namespace SimpleApiWithDynamoDb.Summaries;

public class UpdateUserSummary : Summary<UpdateUserEndpoint>
{
    public UpdateUserSummary()
    {
        Summary = "Updates an existing user in the system";
        Description = "Updates an existing user in the system";
        Response<UserResponse>(201, "User updated successfully");
        Response<ValidationFailureResponse>(400, "The request did not pass validation");
    }
}