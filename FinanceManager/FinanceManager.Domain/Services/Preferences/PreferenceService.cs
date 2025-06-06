using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.UnitOfWork;

namespace FinanceManager.Domain.Services.Preferences;

public class PreferenceService : BaseService, IPreferenceService
{
    private readonly IRepository<UserPreference> _repository;
    public PreferenceService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _repository = _unitOfWork.GetRepository<UserPreference>();
    }

    public async Task<IResult<UserPreferencesModel>> GetPreferencesOfUserAsync(Guid userId)
    {
        try
        {
            var data = await _repository.FindBy(u => u.UserId == userId);

            return Result<UserPreferencesModel>.Success(
                    _mapper.Map<UserPreferencesModel>(data));
        }
        catch (Exception e)
        {
            return Result<UserPreferencesModel>.Fail(e.Message);
        }
    }

    public async Task<IResult> UpdatePreferncesAsync(UserPreferencesModel preferences)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(preferences);

            if (preferences.Id == Guid.Empty || preferences.UserId == Guid.Empty)
                throw new ArgumentException("Id and UserId must be specified");

            _repository.Update(_mapper.Map<UserPreference>(preferences));

            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Preferences updated successfully!");
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }
}
