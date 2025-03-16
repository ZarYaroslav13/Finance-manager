using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Services.Wallets;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceReport.Commands.CreatePeriodReportCommand;

public class CreatePeriodReportHandler : BaseHandler, IRequestHandler<CreatePeriodReportCommand, BaseResponse<FinanceReportDTO>>
{
    private readonly IFinanceReportCreator _creator;
    private readonly IWalletService _walletService;

    public CreatePeriodReportHandler(IFinanceReportCreator financeReportCreator, IWalletService walletService, IMapper mapper, ILogger<BaseHandler> logger) : base(mapper, logger)
    {
        _creator = financeReportCreator ?? throw new ArgumentNullException(nameof(financeReportCreator));
        _walletService = walletService ?? throw new ArgumentNullException(nameof(walletService));
    }

    public async Task<BaseResponse<FinanceReportDTO>> Handle(CreatePeriodReportCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<FinanceReportDTO>();

        try
        {
            await CheckIsUserResourceOwnerOrAdminAsync(request,
                addinionallyCondition:
                    async () =>
                        await _walletService.IsAccountOwnerWalletAsync(request.UserId, request.WalletId));

            var wallet = await _walletService.FindWalletAsync(request.WalletId);

            response.Data = _mapper.Map<FinanceReportDTO>(
                    await _creator.CreateFinanceReportAsync(wallet, request.StartDate, request.EndDate));

            response.MakeAsSuccess("Report created successfully!");
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}
