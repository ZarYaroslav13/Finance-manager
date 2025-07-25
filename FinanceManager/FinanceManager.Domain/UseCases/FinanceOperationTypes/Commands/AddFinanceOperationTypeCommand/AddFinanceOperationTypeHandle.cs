using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.FinanceOperationTypes.Commands.AddFinanceOperationTypeCommand;

public class AddFinanceOperationTypeHandle : BaseRequestHandler, IRequestHandler<AddFinanceOperationTypeCommand, Result<FinanceOperationTypeModel>>
{
    private readonly IRepository<FinanceOperationType> _repository;

    public AddFinanceOperationTypeHandle(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<FinanceOperationType>();
    }

    public async Task<Result<FinanceOperationTypeModel>> Handle(AddFinanceOperationTypeCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            CheckIsUserHaveAccesToResourse(request, request.IsCallerOwner);

            var data = _mapper.Map<FinanceOperationTypeModel>(
                            _repository.Insert(
                               _mapper.Map<FinanceOperationType>(request)));

            await _unitOfWork.SaveChangesAsync();

            return await Result<FinanceOperationTypeModel>.SuccessAsync(data, "Finance operation type created successfully!");
        });
    }
}
