using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.Models.Base;

namespace FinanceManager.Infrastructure.Models;

public class Wallet : Entity
{
    public string Name { get; set; } = string.Empty;

    public int Balance { get; set; }

    public List<FinanceOperationType>? FinanceOperationTypes { get; set; } = new();

    public Guid UserId { get; set; }

    public FinanceManagerUser User { get; set; } = default!;

    public List<FinanceOperation> GetFinanceOperations()
    {
        List<FinanceOperation> result = new();

        if (FinanceOperationTypes != null)
        {
            foreach (var transactionType in FinanceOperationTypes)
            {
                if (transactionType.FinanceOperations == null)
                    continue;

                result.AddRange(transactionType.FinanceOperations);
            }
        }

        return result;
    }

    public override void Copy<T>(T source)
    {
        if (source.GetType() != typeof(Wallet))
            return;

        var sourceWallet = source as Wallet;

        Name = sourceWallet.Name;
        Balance = sourceWallet.Balance;
        UserId = sourceWallet.UserId;
        User = sourceWallet.User;
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj))
            return false;

        var wallet = (Wallet)obj;

        return Name == wallet.Name
                && Balance == wallet.Balance
                && UserId == wallet.UserId
                && AreEqualLists(FinanceOperationTypes, wallet.FinanceOperationTypes)
                && AreEqualLists(GetFinanceOperations(), wallet.GetFinanceOperations());
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Name, Balance, GetHashCodeOfList(FinanceOperationTypes), UserId, User);
    }
}