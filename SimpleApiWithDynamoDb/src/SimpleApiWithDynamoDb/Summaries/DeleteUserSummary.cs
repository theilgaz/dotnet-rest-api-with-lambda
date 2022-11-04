using FastEndpoints;
using SimpleApiWithDynamoDb.Endpoints;

namespace SimpleApiWithDynamoDb.Summaries;

public class DeleteUserSummary : Summary<DeleteUserEndpoint>
{
    public DeleteUserSummary()
    {
        Summary = "Deletes a user in the system";
        Description = "Deletes a user in the system";
        Response(204, "User deleted successfully");
        Response(404, "User not found");
    }
}