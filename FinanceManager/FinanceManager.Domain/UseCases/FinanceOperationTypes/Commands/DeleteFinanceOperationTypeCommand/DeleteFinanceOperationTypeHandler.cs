using AutoMapper;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;
using FinanceManager.Infrastructure.UnitOfWork;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Domain.UseCases.FinanceOperationTypes.Commands.DeleteFinanceOperationTypeCommand;

public class DeleteFinanceOperationTypeHandler : BaseRequestHandler, IRequestHandler<DeleteFinanceOperationTypeCommand, IResult>
{
    private readonly IRepository<FinanceOperationType> _repository;
    private readonly IRepository<FinanceOperation> _financeOperationRepository;

    public DeleteFinanceOperationTypeHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<FinanceOperationType>();
        _financeOperationRepository = _unitOfWork.GetRepository<FinanceOperation>();
    }

    public async Task<IResult> Handle(DeleteFinanceOperationTypeCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            CheckIsUserHaveAccesToResourse(request, request.IsCallerOwner);

            if ((await _financeOperationRepository.GetAllAsync(
                includeProperties: nameof(FinanceOperation.Type),
                filter: fo => fo.Type.Id == request.Id))
            .Any())
            {
                throw new InvalidOperationException($"Deleting type with Id: {request.Id} is imposible through operations with this type exists");
            }

            _repository.Delete(request.Id);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Finance operation type deleted successfully!");
        });
    }
}
