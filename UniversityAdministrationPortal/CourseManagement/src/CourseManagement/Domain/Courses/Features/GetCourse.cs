namespace CourseManagement.Domain.Courses.Features;

using CourseManagement.Domain.Courses.Dtos;
using CourseManagement.Domain.Courses.Services;
using CourseManagement.Exceptions;
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