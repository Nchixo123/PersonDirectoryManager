using System.ComponentModel.DataAnnotations;

namespace PersonDirectory.Model.Attributes
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
            ErrorMessage = $"The age must be at least {_minimumAge} years.";
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateOfBirth)
            {
                if (dateOfBirth.AddYears(_minimumAge) >= DateTime.Now)
                {
                   return ValidationResult.Success;
                }
            }
             return new ValidationResult(ErrorMessage);
        }
    }
}
