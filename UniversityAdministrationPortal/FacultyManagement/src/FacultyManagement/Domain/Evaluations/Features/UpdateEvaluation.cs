namespace FacultyManagement.Domain.Evaluations.Features;

using FacultyManagement.Domain.Evaluations;
using FacultyManagement.Domain.Evaluations.Dtos;
using FacultyManagement.Domain.Evaluations.Services;
using FacultyManagement.Services;
using FacultyManagement.Domain.Evaluations.Models;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateEvaluation
{
    public sealed record Command(Guid EvaluationId, EvaluationForUpdateDto UpdatedEvaluationData) : IRequest;

    public sealed class Handler(IEvaluationRepository evaluationRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var evaluationToUpdate = await evaluationRepository.GetById(request.EvaluationId, cancellationToken: cancellationToken);
            var evaluationToAdd = request.UpdatedEvaluationData.ToEvaluationForUpdate();
            evaluationToUpdate.Update(evaluationToAdd);

            evaluationRepository.Update(evaluationToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}