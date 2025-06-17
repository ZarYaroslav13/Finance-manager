using System.Text.Json.Serialization;

namespace FinanceManager.Infrastructure.Models;


[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EntryType
{
    Income,
    Expense
}

