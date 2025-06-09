using ApexCharts;

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
