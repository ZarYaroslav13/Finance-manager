using FinanceManager.Domain.Models;
using FinanceManager.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Domain.Extentions;

public static class WalletExtention
{
    public static void CalculateNewBalance(this Wallet wallet, FinanceOperationModel financeOperation, EntryType oldType, int oldAmount)
    {
        var type = financeOperation.Type;

        bool isAmountUnchanged = oldAmount == financeOperation.Amount;
        bool isTypeUnchanged = oldType == type.EntryType;
        bool isTypeIncome = type.EntryType == EntryType.Income;

        if (isTypeUnchanged && !isAmountUnchanged)
        {
            if (isTypeIncome)
            {
                wallet.Balance += financeOperation.Amount - oldAmount;
                return;
            }

            wallet.Balance -= financeOperation.Amount + oldAmount;
        }

        if (!isTypeUnchanged && isAmountUnchanged)
        {
            if (isTypeIncome)
            {
                wallet.Balance += 2 * oldAmount;
                return;
            }

            wallet.Balance -= 2 * oldAmount;
        }

        if (!isTypeUnchanged && !isAmountUnchanged)
        {
            if (isTypeIncome)
            {
                wallet.Balance += oldAmount + financeOperation.Amount;
                return;
            }

            wallet.Balance -= oldAmount - financeOperation.Amount;
        }

    }

    public static void CalculateNewBalance(this Wallet wallet, FinanceOperation financeOperation, EntryType oldType, int oldAmount)
    {
        var type = financeOperation.Type;

        bool isAmountUnchanged = oldAmount == financeOperation.Amount;
        bool isTypeUnchanged = oldType == type.EntryType;
        bool isTypeIncome = type.EntryType == EntryType.Income;

        if (isTypeUnchanged && !isAmountUnchanged)
        {
            if (isTypeIncome)
            {
                wallet.Balance += (int)financeOperation.Amount - oldAmount;
                return;
            }

            wallet.Balance -= (int)financeOperation.Amount + oldAmount;
        }

        if (!isTypeUnchanged && isAmountUnchanged)
        {
            if (isTypeIncome)
            {
                wallet.Balance += 2 * oldAmount;
                return;
            }

            wallet.Balance -= 2 * oldAmount;
        }

        if (!isTypeUnchanged && !isAmountUnchanged)
        {
            if (isTypeIncome)
            {
                wallet.Balance += oldAmount + (int)financeOperation.Amount;
                return;
            }

            wallet.Balance -= oldAmount - (int)financeOperation.Amount;
        }

    }
}
