namespace FacultyManagement.Domain.Evaluations.Features;

using FacultyManagement.Domain.Evaluations.Services;
using FacultyManagement.Domain.Evaluations;
using FacultyManagement.Domain.Evaluations.Dtos;
using FacultyManagement.Domain.Evaluations.Models;
using FacultyManagement.Services;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddEvaluation
{
    public sealed record Command(EvaluationForCreationDto EvaluationToAdd) : IRequest<EvaluationDto>;

    public sealed class Handler(IEvaluationRepository evaluationRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, EvaluationDto>
    {
        public async Task<EvaluationDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var evaluationToAdd = request.EvaluationToAdd.ToEvaluationForCreation();
            var evaluation = Evaluation.Create(evaluationToAdd);

            await evaluationRepository.Add(evaluation, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return evaluation.ToEvaluationDto();
        }
    }
}