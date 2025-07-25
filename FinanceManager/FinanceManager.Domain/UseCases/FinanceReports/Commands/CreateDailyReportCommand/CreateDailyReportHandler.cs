using AutoMapper;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceReports.Commands.CreateDailyReportCommand;

public class CreateDailyReportHandler : BaseRequestHandler, IRequestHandler<CreateDailyReportCommand, Result<FinanceReportDTO>>
{
    private readonly IFinanceReportCreator _creator;
    private readonly IWalletService _walletService;

    public CreateDailyReportHandler(
        IFinanceReportCreator creator, IWalletService walletService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _creator = creator ?? throw new ArgumentNullException(nameof(creator));
        _walletService = walletService ?? throw new ArgumentNullException(nameof(walletService));
    }

    public async Task<Result<FinanceReportDTO>> Handle(CreateDailyReportCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await _walletService.IsCallerWalletOwner(request.WalletId));

            DateTime date = request.Date ?? throw new ArgumentNullException(nameof(request.Date));

            var wallet = await _walletService.FindWalletAsync(request.WalletId);

            var data = _mapper.Map<FinanceReportDTO>(
                    await _creator.CreateFinanceReportAsync(wallet, date));

            data.Balance = wallet.Balance;

            return Result<FinanceReportDTO>.Success(data, "Report created successfully!");
        });
    }
}
