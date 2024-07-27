namespace CourseManagement.Domain.Resources.Features;

using CourseManagement.Domain.Resources.Services;
using CourseManagement.Services;
using CourseManagement.Exceptions;
using MediatR;

public static class DeleteResource
{
    public sealed record Command(Guid ResourceId) : IRequest;

    public sealed class Handler(IResourceRepository resourceRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await resourceRepository.GetById(request.ResourceId, cancellationToken: cancellationToken);
            resourceRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}