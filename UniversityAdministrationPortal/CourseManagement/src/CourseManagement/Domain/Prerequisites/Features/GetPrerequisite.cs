namespace CourseManagement.Domain.Prerequisites.Features;

using CourseManagement.Domain.Prerequisites.Dtos;
using CourseManagement.Domain.Prerequisites.Services;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetPrerequisite
{
    public sealed record Query(Guid PrerequisiteId) : IRequest<PrerequisiteDto>;

    public sealed class Handler(IPrerequisiteRepository prerequisiteRepository)
        : IRequestHandler<Query, PrerequisiteDto>
    {
        public async Task<PrerequisiteDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await prerequisiteRepository.GetById(request.PrerequisiteId, cancellationToken: cancellationToken);
            return result.ToPrerequisiteDto();
        }
    }
}