using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public async Task<IResult<UserPreferencesModel>> GetPreferencesOfUser(Guid userId)
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

    public async Task<IResult<UserPreferencesModel>> AddPreferences(UserPreferencesModel preferences)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(preferences);

            if (preferences.Id != Guid.Empty)
                throw new ArgumentException("id cannot be specified ");

            if (preferences.UserId == Guid.Empty)
                throw new ArgumentException("UserId must be specified ");

            var data = _mapper.Map<UserPreferencesModel>(
                        _repository.Insert(
                            _mapper.Map<UserPreference>(preferences)));

            await _unitOfWork.SaveChangesAsync();

            return Result<UserPreferencesModel>.Success(data, "Added preferencess successfully!");
        }
        catch (Exception e)
        {
            return Result<UserPreferencesModel>.Fail(e.Message);
        }
    }

    public async Task<IResult> UpdatePrefernces(UserPreferencesModel preferences)
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
