namespace FacultyManagement.Domain.CourseAssignments.Features;

using FacultyManagement.Domain.CourseAssignments.Dtos;
using FacultyManagement.Domain.CourseAssignments.Services;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetCourseAssignment
{
    public sealed record Query(Guid CourseAssignmentId) : IRequest<CourseAssignmentDto>;

    public sealed class Handler(ICourseAssignmentRepository courseAssignmentRepository)
        : IRequestHandler<Query, CourseAssignmentDto>
    {
        public async Task<CourseAssignmentDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await courseAssignmentRepository.GetById(request.CourseAssignmentId, cancellationToken: cancellationToken);
            return result.ToCourseAssignmentDto();
        }
    }
}