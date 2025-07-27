using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.Models;

public class WalletDTO : Base.ModelDTO
{
    public string Name
    {
        get { return _name; }
        set { _name = value.Trim(); }
    }

    public int Balance { get; set; } = 0;

    public List<FinanceOperationTypeDTO> FinanceOperationTypes { get; set; } = new();

    public List<IncomeDTO> Incomes { get; set; } = new();

    public List<ExpenseDTO> Expenses { get; set; } = new();

    public Guid UserId { get; set; }

    private string _name = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj))
            return false;

        WalletDTO wallet = (WalletDTO)obj;

        return Name == wallet.Name
                && Balance == wallet.Balance
                && UserId == wallet.UserId
                && AreEqualLists(FinanceOperationTypes, wallet.FinanceOperationTypes)
                && AreEqualLists(Incomes, wallet.Incomes)
                && AreEqualLists(Expenses, wallet.Expenses);
    }

    public override int GetHashCode()
    {
        var financeOperationTypesHashValue = GetHashCodeOfList(FinanceOperationTypes);
        var incomesHashValue = GetHashCodeOfList(Incomes);
        var expensesHashValue = GetHashCodeOfList(Expenses);

        return HashCode.Combine(base.GetHashCode(), Name, Balance, UserId, financeOperationTypesHashValue, incomesHashValue, expensesHashValue);
    }
}