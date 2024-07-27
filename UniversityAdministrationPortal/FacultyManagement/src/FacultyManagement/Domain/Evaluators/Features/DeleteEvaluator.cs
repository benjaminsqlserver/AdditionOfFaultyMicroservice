namespace FacultyManagement.Domain.Evaluators.Features;

using FacultyManagement.Domain.Evaluators.Services;
using FacultyManagement.Services;
using FacultyManagement.Exceptions;
using MediatR;

public static class DeleteEvaluator
{
    public sealed record Command(Guid EvaluatorId) : IRequest;

    public sealed class Handler(IEvaluatorRepository evaluatorRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await evaluatorRepository.GetById(request.EvaluatorId, cancellationToken: cancellationToken);
            evaluatorRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}