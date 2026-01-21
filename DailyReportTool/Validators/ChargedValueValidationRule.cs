using System.Globalization;
using System.Windows.Controls;

namespace DailyReportTool.Validators;

public class ChargedValueValidationRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value == null)
        {
            return new ValidationResult(false, "Value cannot be null.");
        }

        string? stringValue = value.ToString();
        
        if (string.IsNullOrWhiteSpace(stringValue))
        {
            return new ValidationResult(false, "Value cannot be empty.");
        }

        if (int.TryParse(stringValue, out int intValue))
        {
            if (intValue == 0 || intValue == 1)
            {
                return ValidationResult.ValidResult;
            }
        }

        return new ValidationResult(false, "Charged must be 0 or 1.");
    }
}
