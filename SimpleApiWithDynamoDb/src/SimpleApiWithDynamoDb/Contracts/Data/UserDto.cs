using System.Text.Json.Serialization;

namespace SimpleApiWithDynamoDb.Contracts.Data;

public class UserDto
{
    [JsonPropertyName("pk")]
    public string Pk => Id;

    [JsonPropertyName("sk")]
    public string Sk => Id;

    public string Id { get; init; } = default!;
    public string FullName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Password { get; init; } = default!;
}