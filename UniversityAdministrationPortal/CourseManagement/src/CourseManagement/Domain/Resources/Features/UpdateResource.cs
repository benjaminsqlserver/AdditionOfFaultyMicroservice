namespace CourseManagement.Domain.Resources.Features;

using CourseManagement.Domain.Resources;
using CourseManagement.Domain.Resources.Dtos;
using CourseManagement.Domain.Resources.Services;
using CourseManagement.Services;
using CourseManagement.Domain.Resources.Models;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateResource
{
    public sealed record Command(Guid ResourceId, ResourceForUpdateDto UpdatedResourceData) : IRequest;

    public sealed class Handler(IResourceRepository resourceRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var resourceToUpdate = await resourceRepository.GetById(request.ResourceId, cancellationToken: cancellationToken);
            var resourceToAdd = request.UpdatedResourceData.ToResourceForUpdate();
            resourceToUpdate.Update(resourceToAdd);

            resourceRepository.Update(resourceToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}