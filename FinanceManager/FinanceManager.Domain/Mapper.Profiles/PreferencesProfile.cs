using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Domain.Mapper.Profiles;

public class PreferencesProfile : Profile
{
    public PreferencesProfile()
    {
        CreateMap<UserPreference, UserPreferencesModel>().ReverseMap();
    }
}
