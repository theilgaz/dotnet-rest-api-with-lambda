using ValueOf;

namespace SimpleApiWithDynamoDb.Domain.Common;

public class UserId : ValueOf<Guid, UserId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
        {
            throw new ArgumentException("UserId cannot be empty", nameof(UserId));
        }
    }
}