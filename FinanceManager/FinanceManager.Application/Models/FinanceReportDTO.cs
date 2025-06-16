using FinanceManager.Domain.Models;

namespace FinanceManager.Application.Models;

public class FinanceReportDTO : Base.ModelDTO
{
    public Guid WalletId { get; set; }
    public string WalletName { get; set; } = String.Empty;

    public int Balance { get; set; }

    public int TotalIncome { get; set; }
    public int TotalExpense { get; set; }
    public List<FinanceOperationDTO> Operations { get; set; }
    public Period Period { get; set; }

    public FinanceReportDTO()
    {

    }

    public FinanceReportDTO(
        Guid walletId,
        string walletName,
        int totalIncome,
        int totalExpense,
        List<FinanceOperationDTO> operation,
        Period period)
    {
        WalletId = walletId;
        WalletName = walletName ?? throw new ArgumentNullException(nameof(walletName));
        TotalIncome = totalIncome;
        TotalExpense = totalExpense;
        Operations = operation ?? throw new ArgumentNullException(nameof(operation));
        Period = period;
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj))
            return false;

        var financeReport = (FinanceReportDTO)obj;

        return WalletId == financeReport.WalletId
            && WalletName == financeReport.WalletName
            && TotalIncome == financeReport.TotalIncome
            && TotalExpense == financeReport.TotalExpense
            && Period == financeReport.Period
            && AreEqualLists(Operations, financeReport.Operations);
    }

    public override int GetHashCode()
    {
        int operationHashCode = GetHashCodeOfList(Operations);

        return HashCode.Combine(base.GetHashCode(), WalletId, WalletName, TotalIncome, TotalExpense, Period, operationHashCode);
    }
}
