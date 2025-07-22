using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.DataAnnotations.Attributes;

public class GuidRequiredAttribute : ValidationAttribute
{
    public GuidRequiredAttribute()
    {
        ErrorMessage = "Guid must be not empty";
    }

    public override bool IsValid(object? value)
    {
        return value is Guid guid && guid != Guid.Empty;
    }
}
