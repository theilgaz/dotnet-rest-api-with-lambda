using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace SimpleApiWithDynamoDb.Domain.Common;

public class FullName : ValueOf<string, FullName>
{
    private static readonly Regex NameRegex = new Regex(@"^[a-z ,.'-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    
    protected override void Validate()
    {
        if (!NameRegex.IsMatch(Value))
        {
            var message = $"Invalid name: {Value}";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(FullName), message)
            });
        }
            
    }
}