using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Services.Wallets;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceReport.Commands.CreatePeriodReportCommand;

public class CreatePeriodReportHandler : BaseRequestHandler, IRequestHandler<CreatePeriodReportCommand, Result<FinanceReportDTO>>
{
    private readonly IFinanceReportCreator _creator;
    private readonly IWalletService _walletService;

    public CreatePeriodReportHandler(IFinanceReportCreator creator, IWalletService walletService, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _creator = creator ?? throw new ArgumentNullException(nameof(creator));
        _walletService = walletService ?? throw new ArgumentNullException(nameof(walletService));
    }

    public async Task<Result<FinanceReportDTO>> Handle(CreatePeriodReportCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
                request.WalletId,
                w => w.AccountId,
                async () => await _walletService.FindWalletAsync(Guid.Parse(request.WalletId)));

            var wallet = await _walletService.FindWalletAsync(Guid.Parse(request.WalletId));

            var data = _mapper.Map<FinanceReportDTO>(
                    await _creator.CreateFinanceReportAsync(wallet, request.StartDate, request.EndDate));

            return Result<FinanceReportDTO>.Success(data, "Report created successfully!");
        }
        catch (Exception e)
        {
            return Result<FinanceReportDTO>.Fail(e.Message);
        }
    }
}
