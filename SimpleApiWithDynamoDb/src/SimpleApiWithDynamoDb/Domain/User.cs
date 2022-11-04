using SimpleApiWithDynamoDb.Domain.Common;

namespace SimpleApiWithDynamoDb.Domain;

public class User
{
    public UserId Id { get; init; } = UserId.From(Guid.NewGuid());
    public EmailAddress EmailAddress { get; init; } = default!;
    public FullName FullName { get; init; } = default!;
    public Password Password { get; init; } = default!;
}