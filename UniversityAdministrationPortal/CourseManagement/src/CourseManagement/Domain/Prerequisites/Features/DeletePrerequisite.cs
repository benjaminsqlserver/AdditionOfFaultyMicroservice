namespace CourseManagement.Domain.Prerequisites.Features;

using CourseManagement.Domain.Prerequisites.Services;
using CourseManagement.Services;
using CourseManagement.Exceptions;
using MediatR;

public static class DeletePrerequisite
{
    public sealed record Command(Guid PrerequisiteId) : IRequest;

    public sealed class Handler(IPrerequisiteRepository prerequisiteRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await prerequisiteRepository.GetById(request.PrerequisiteId, cancellationToken: cancellationToken);
            prerequisiteRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}