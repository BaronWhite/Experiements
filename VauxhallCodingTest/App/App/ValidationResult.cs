using System.Collections.Generic;

namespace App
{
    internal class ValidationResult
    {
        private List<string> validationErrors = new List<string>();

        public bool IsValid { get; private set; } = true;

        public List<string> GetValidationErrors()
        {
            return validationErrors;
        }

        public void LogValidationError(string validationError)
        {
            IsValid = false;
            validationErrors.Add(string.IsNullOrEmpty(validationError) ? "No error message." : validationError);
        }

        public void Validate(string validationError)
        {
            if (!string.IsNullOrEmpty(validationError))
            {
                IsValid = false;
                validationErrors.Add(validationError);
            }
        }

    }
}
