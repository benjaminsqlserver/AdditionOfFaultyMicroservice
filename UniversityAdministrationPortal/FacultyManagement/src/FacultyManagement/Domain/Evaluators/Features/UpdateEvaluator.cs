namespace FacultyManagement.Domain.Evaluators.Features;

using FacultyManagement.Domain.Evaluators;
using FacultyManagement.Domain.Evaluators.Dtos;
using FacultyManagement.Domain.Evaluators.Services;
using FacultyManagement.Services;
using FacultyManagement.Domain.Evaluators.Models;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateEvaluator
{
    public sealed record Command(Guid EvaluatorId, EvaluatorForUpdateDto UpdatedEvaluatorData) : IRequest;

    public sealed class Handler(IEvaluatorRepository evaluatorRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var evaluatorToUpdate = await evaluatorRepository.GetById(request.EvaluatorId, cancellationToken: cancellationToken);
            var evaluatorToAdd = request.UpdatedEvaluatorData.ToEvaluatorForUpdate();
            evaluatorToUpdate.Update(evaluatorToAdd);

            evaluatorRepository.Update(evaluatorToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}