namespace FinanceManager.Domain.API;

public record class APIOptions
{
    public static string Section = "APIOptions";

    public string BaseAddress { get; set; }
}
