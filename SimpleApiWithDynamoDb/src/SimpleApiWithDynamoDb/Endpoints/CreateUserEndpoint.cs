using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using SimpleApiWithDynamoDb.Contracts.Requests;
using SimpleApiWithDynamoDb.Contracts.Responses;
using SimpleApiWithDynamoDb.Mapping;
using SimpleApiWithDynamoDb.Services;

namespace SimpleApiWithDynamoDb.Endpoints;

[HttpPost("users"), AllowAnonymous]
public class CreateUserEndpoint : Endpoint<CreateUserRequest, UserResponse>
{
    private readonly IUserService _userService;

    public CreateUserEndpoint(IUserService userService)
    {
        _userService = userService;
    }

    public override async Task HandleAsync(CreateUserRequest request, CancellationToken ct)
    {
        var user = request.ToUser();
        await _userService.CreateAsync(user);
        var response = user.ToUserResponse();
        await SendCreatedAtAsync<GetUserEndpoint>(new { Id = user.Id.Value }, response, generateAbsoluteUrl: true, cancellation: ct);
    }
}