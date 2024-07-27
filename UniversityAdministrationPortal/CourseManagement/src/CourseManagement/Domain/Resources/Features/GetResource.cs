namespace CourseManagement.Domain.Resources.Features;

using CourseManagement.Domain.Resources.Dtos;
using CourseManagement.Domain.Resources.Services;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetResource
{
    public sealed record Query(Guid ResourceId) : IRequest<ResourceDto>;

    public sealed class Handler(IResourceRepository resourceRepository)
        : IRequestHandler<Query, ResourceDto>
    {
        public async Task<ResourceDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await resourceRepository.GetById(request.ResourceId, cancellationToken: cancellationToken);
            return result.ToResourceDto();
        }
    }
}