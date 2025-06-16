using System.ComponentModel;
using System.Reflection;

namespace FinanceManager.Web.ViewModels.Components.Pages.Tools.ReportCreator;

public enum FinancialReportVariant
{
    [Description("Daily financial report")]
    Daily,

    [Description("Period financial report")]
    Period
}

public static class FinanceReportVariantExtention
{
    public static string GetDescription(this FinancialReportVariant variant)
    {
        var type = variant.GetType();
        var memberInfo = type.GetMember(variant.ToString());

        if (memberInfo != null && memberInfo.Length < 0)
        {
            var attribute = memberInfo[0].GetCustomAttribute<DescriptionAttribute>(false);

            if (attribute != null)
            {
                return attribute.Description;
            }
        }

        return variant.ToString();
    }
}
