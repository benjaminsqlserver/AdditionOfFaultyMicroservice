namespace FacultyManagement.Domain.Courses.Features;

using FacultyManagement.Domain.Courses.Dtos;
using FacultyManagement.Domain.Courses.Services;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetCourse
{
    public sealed record Query(Guid CourseId) : IRequest<CourseDto>;

    public sealed class Handler(ICourseRepository courseRepository)
        : IRequestHandler<Query, CourseDto>
    {
        public async Task<CourseDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await courseRepository.GetById(request.CourseId, cancellationToken: cancellationToken);
            return result.ToCourseDto();
        }
    }
}