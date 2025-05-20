namespace FinanceManager.Domain.API;

record class APIOptions
{
    public static string Section = "APIOptions";

    public string BaseAddress { get; set; }
}
