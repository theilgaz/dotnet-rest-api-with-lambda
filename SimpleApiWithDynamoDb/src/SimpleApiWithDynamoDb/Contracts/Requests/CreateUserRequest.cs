namespace SimpleApiWithDynamoDb.Contracts.Requests;

public class CreateUserRequest
{
    public string FullName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Password { get; init; } = default!;
}