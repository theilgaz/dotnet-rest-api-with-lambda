using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SimpleApiWithDynamoDb.Contracts.Requests;
using SimpleApiWithDynamoDb.Contracts.Responses;
using SimpleApiWithDynamoDb.Mapping;
using SimpleApiWithDynamoDb.Services;

namespace SimpleApiWithDynamoDb.Endpoints;

[HttpPut("users/{id:guid}"), AllowAnonymous]
public class UpdateUserEndpoint : Endpoint<UpdateUserRequest, UserResponse>
{
    private readonly IUserService _userService;

    public UpdateUserEndpoint(IUserService userService)
    {
        _userService = userService;
    }

    public override async Task HandleAsync(UpdateUserRequest request, CancellationToken ct)
    {
        var existingUser = await _userService.GetAsync(request.Id);
        
        if (existingUser is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var user = request.ToUser();
        await _userService.UpdateAsync(user);
        
        var response = user.ToUserResponse();
        await SendOkAsync(response, ct);
    }
}