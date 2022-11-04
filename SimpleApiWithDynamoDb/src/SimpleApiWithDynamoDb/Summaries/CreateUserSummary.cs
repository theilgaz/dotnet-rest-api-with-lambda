using FastEndpoints;
using SimpleApiWithDynamoDb.Contracts.Responses;
using SimpleApiWithDynamoDb.Endpoints;

namespace SimpleApiWithDynamoDb.Summaries;

public class CreateUserSummary : Summary<CreateUserEndpoint>
{
    public CreateUserSummary()
    {
        Summary = "Creates a new user in the system";
        Description = "Creates a new user in the system";
        Response<UserResponse>(201,"User was created successfully");
        Response<ValidationFailureResponse>(400,"The request did not pass validation");
    }
}