using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SimpleApiWithDynamoDb.Contracts.Requests;
using SimpleApiWithDynamoDb.Services;

namespace SimpleApiWithDynamoDb.Endpoints;

[HttpDelete("users/{id:guid}"),AllowAnonymous]
public class DeleteUserEndpoint : Endpoint<DeleteUserRequest>
{
    private readonly IUserService _userService;

    public DeleteUserEndpoint(IUserService userService)
    {
        _userService = userService;
    }

    public override async Task HandleAsync(DeleteUserRequest request, CancellationToken ct)
    {
        var deleted = await _userService.DeleteAsync(request.Id);
        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(ct);
    }
    
}