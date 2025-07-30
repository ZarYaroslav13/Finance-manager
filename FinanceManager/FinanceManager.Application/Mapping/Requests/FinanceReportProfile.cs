using AutoMapper;
using FinanceManager.Application.Models.Requests.FinanceOperations.Queries;
using FinanceManager.Application.Models.Requests.FinanceReports.Commands;

namespace FinanceManager.Application.Mapping.Requests;

public class FinanceReportProfile : Profile
{
    public FinanceReportProfile()
    {
        CreateMap<CreateDailyReportRequest, CreatePeriodReportRequest>()
            .ForMember(dest => dest.StartDate, conf => conf.MapFrom(src => src.Date))
            .ForMember(dest => dest.EndDate, conf => conf.MapFrom(src => src.Date));

        CreateMap<CreatePeriodReportRequest, GetAllOperationsOfWalletInPeriodRequest>();
    }
}
