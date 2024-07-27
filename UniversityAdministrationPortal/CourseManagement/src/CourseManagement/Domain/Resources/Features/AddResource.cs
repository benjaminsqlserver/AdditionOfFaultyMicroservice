namespace CourseManagement.Domain.Resources.Features;

using CourseManagement.Domain.Resources.Services;
using CourseManagement.Domain.Resources;
using CourseManagement.Domain.Resources.Dtos;
using CourseManagement.Domain.Resources.Models;
using CourseManagement.Services;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddResource
{
    public sealed record Command(ResourceForCreationDto ResourceToAdd) : IRequest<ResourceDto>;

    public sealed class Handler(IResourceRepository resourceRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, ResourceDto>
    {
        public async Task<ResourceDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var resourceToAdd = request.ResourceToAdd.ToResourceForCreation();
            var resource = Resource.Create(resourceToAdd);

            await resourceRepository.Add(resource, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return resource.ToResourceDto();
        }
    }
}