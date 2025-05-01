namespace FinanceManager.Web.API;

record class APIOptions
{
    public static string Section = "APIOptions";

    public string BaseAddress { get; set; }
}
