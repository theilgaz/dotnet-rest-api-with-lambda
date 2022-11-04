namespace SimpleApiWithDynamoDb.Contracts.Requests;

public class UpdateUserRequest
{
    public Guid Id { get; init; }
    public string FullName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Password { get; init; } = default!;
}