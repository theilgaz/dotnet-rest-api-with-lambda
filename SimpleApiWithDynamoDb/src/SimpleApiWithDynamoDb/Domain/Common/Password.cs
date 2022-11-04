using System.Text.RegularExpressions;
using ValueOf;

namespace SimpleApiWithDynamoDb.Domain.Common;

public class Password: ValueOf<string, Password>
{
    //private static readonly Regex PasswordRegex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>\\/?]).{8,}$");
    
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value))
            throw new ArgumentException("Password cannot be empty", nameof(Value));
        
       // if (!PasswordRegex.IsMatch(Value)) throw new ArgumentException("Password must contain at least one uppercase letter, one lowercase letter, one number and one special character", nameof(Value));
    }
}