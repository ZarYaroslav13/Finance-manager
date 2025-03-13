using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.Wallet.Commands.CreateWalletCommand;

public class CreateWalletCommand : IRequest<BaseResponse<WalletDTO>>
{
    public int AccountId { get; set; }

    [Required]
    [Length(2, 50)]
    public string Name { get; set; }
}
