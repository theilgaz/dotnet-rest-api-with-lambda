using FastEndpoints;
using SimpleApiWithDynamoDb.Contracts.Responses;
using SimpleApiWithDynamoDb.Endpoints;

namespace SimpleApiWithDynamoDb.Summaries;

public class GetUserSummary : Summary<GetUserEndpoint>
{
    public GetUserSummary()
    {
        Summary = "Returns a single user";
        Description = "Returns a single user";
        Response<GetAllUsersResponse>(200, "User found and returned successfully");
        Response(404, "User not found");
    }
}