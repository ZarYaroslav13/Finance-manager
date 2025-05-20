using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Services.Wallets;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceReport.Commands.CreateDailyReportCommand;

public class CreateDailyReportHandler : BaseRequestHandler, IRequestHandler<CreateDailyReportCommand, Result<FinanceReportDTO>>
{
    private readonly IFinanceReportCreator _creator;
    private readonly IWalletService _walletService;

    public CreateDailyReportHandler(ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
    }

    public async Task<Result<FinanceReportDTO>> Handle(CreateDailyReportCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
                addinionallyCondition:
                    async () =>
                        await _walletService.IsAccountOwnerWalletAsync(_currentUserService.UserId, request.WalletId));

            var wallet = await _walletService.FindWalletAsync(request.WalletId);

            var data = _mapper.Map<FinanceReportDTO>(
                    await _creator.CreateFinanceReportAsync(wallet, request.Date));

            return Result<FinanceReportDTO>.Success(data, "Report created successfully!");
        }
        catch (Exception e)
        {
            return Result<FinanceReportDTO>.Fail(e.Message);
        }
    }
}
