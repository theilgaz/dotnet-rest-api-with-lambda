using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SimpleApiWithDynamoDb.Contracts.Requests;
using SimpleApiWithDynamoDb.Contracts.Responses;
using SimpleApiWithDynamoDb.Mapping;
using SimpleApiWithDynamoDb.Services;

namespace SimpleApiWithDynamoDb.Endpoints;

[HttpGet("users/{id:guid}"), AllowAnonymous]
public class GetUserEndpoint : Endpoint<GetUserRequest, UserResponse>
{
    private readonly IUserService _userService;

    public GetUserEndpoint(IUserService userService)
    {
        _userService = userService;
    }
    
    public override async Task HandleAsync(GetUserRequest request, CancellationToken ct)
    {
        var user = await _userService.GetAsync(request.Id);
        if (user is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var userResponse = user.ToUserResponse();
        await SendOkAsync(userResponse, ct);
    }
}