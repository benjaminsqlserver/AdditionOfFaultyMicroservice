namespace FacultyManagement.Domain.Evaluators.Features;

using FacultyManagement.Domain.Evaluators.Services;
using FacultyManagement.Domain.Evaluators;
using FacultyManagement.Domain.Evaluators.Dtos;
using FacultyManagement.Domain.Evaluators.Models;
using FacultyManagement.Services;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddEvaluator
{
    public sealed record Command(EvaluatorForCreationDto EvaluatorToAdd) : IRequest<EvaluatorDto>;

    public sealed class Handler(IEvaluatorRepository evaluatorRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, EvaluatorDto>
    {
        public async Task<EvaluatorDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var evaluatorToAdd = request.EvaluatorToAdd.ToEvaluatorForCreation();
            var evaluator = Evaluator.Create(evaluatorToAdd);

            await evaluatorRepository.Add(evaluator, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return evaluator.ToEvaluatorDto();
        }
    }
}