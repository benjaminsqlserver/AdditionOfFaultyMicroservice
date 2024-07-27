namespace FacultyManagement.Domain.Evaluations.Features;

using FacultyManagement.Domain.Evaluations.Services;
using FacultyManagement.Services;
using FacultyManagement.Exceptions;
using MediatR;

public static class DeleteEvaluation
{
    public sealed record Command(Guid EvaluationId) : IRequest;

    public sealed class Handler(IEvaluationRepository evaluationRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await evaluationRepository.GetById(request.EvaluationId, cancellationToken: cancellationToken);
            evaluationRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}