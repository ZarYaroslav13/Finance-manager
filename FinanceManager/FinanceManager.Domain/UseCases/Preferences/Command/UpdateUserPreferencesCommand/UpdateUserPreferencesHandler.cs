using AutoMapper;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Constants.Localization;
using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.Preferences.Command.UpdateUserPreferencesCommand;

public class UpdateUserPreferencesHandler : BaseRequestHandler, IRequestHandler<UpdateUserPreferencesCommand, IResult>
{
    private readonly IRepository<UserPreference> _repository;
    public UpdateUserPreferencesHandler(
        IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger)
        : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<UserPreference>();
    }

    public async Task<IResult> Handle(UpdateUserPreferencesCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            CheckIsUserHaveAccesToResourse(request,
                () => _currentUserService.UserId == request.UserId.ToString());

            ArgumentNullException.ThrowIfNull(request);

            if (!LocalizationConstants.SupportedLanguages.Any(l => l.Code == request.LanguageCode))
                throw new ArgumentException("Invalid language code!");

            var preferences = _mapper.Map<UserPreference>(request);

            preferences.Id = (await _repository.FindBy(p => p.UserId == preferences.UserId)).Id;

            _repository.Update(preferences);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Preferences updated successfully!");
        });
    }
}
