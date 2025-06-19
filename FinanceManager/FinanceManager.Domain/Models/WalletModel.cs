using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Domain.Models;

public class WalletModel : Base.Model
{
    public string Name { get; set; } = String.Empty;

    public int Balance { get; set; }

    public List<FinanceOperationTypeModel> FinanceOperationTypes { get; set; } = new();

    public List<IncomeModel> Incomes { get; set; } = new();

    public List<ExpenseModel> Expenses { get; set; } = new();

    public Guid UserId { get; set; }

    public void CalculateNewBalance(FinanceOperationModel financeOperation, EntryType oldType, int oldAmount)
    {
        var type = financeOperation.Type;

        bool isAmountUnchanged = oldAmount == financeOperation.Amount;
        bool isTypeUnchanged = oldType == type.EntryType;
        bool isTypeIncome = type.EntryType == EntryType.Income;

        if (isTypeUnchanged && !isAmountUnchanged)
        {
            if (isTypeIncome)
            {
                Balance += financeOperation.Amount - oldAmount;
                return;
            }

            Balance -= financeOperation.Amount + oldAmount;
        }

        if (!isTypeUnchanged && isAmountUnchanged)
        {
            if (isTypeIncome)
            {
                Balance += 2 * oldAmount;
                return;
            }

            Balance -= 2 * oldAmount;
        }

        if (!isTypeUnchanged && !isAmountUnchanged)
        {
            if (isTypeIncome)
            {
                Balance += oldAmount + financeOperation.Amount;
                return;
            }

            Balance -= oldAmount - financeOperation.Amount;
        }

    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj))
            return false;

        WalletModel wallet = (WalletModel)obj;

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
