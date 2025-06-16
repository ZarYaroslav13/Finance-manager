namespace FinanceManager.Web.Helpers;

public class ApexChartValue<T>
{
    public string Label { get; set; } = "";
    public T Value { get; set; }

    public string Color { get; set; }

    public ApexChartValue()
    {

    }
}

public class ApexChartValue<T, Y>
{
    public string Label { get; set; } = "";
    public T ValueX { get; set; }
    public Y ValueY { get; set; }

    public string Color { get; set; }

    public ApexChartValue()
    {

    }
}
