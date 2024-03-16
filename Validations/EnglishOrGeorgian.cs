using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Validations;

public class EnglishOrGeorgian : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string str)
        {
            string englishPattern = @"^[a-zA-Z]*$";
            string georgianPattern = @"^[ა-ჰ]*$";

            if (Regex.IsMatch(str, englishPattern, RegexOptions.IgnoreCase) || Regex.IsMatch(str, georgianPattern))
            {
                return ValidationResult.Success;
            }
        }

        return new ValidationResult("The string can only contain English or Georgian characters, not both.");
    }
}