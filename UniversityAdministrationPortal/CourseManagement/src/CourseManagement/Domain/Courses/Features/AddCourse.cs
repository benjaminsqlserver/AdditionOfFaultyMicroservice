namespace CourseManagement.Domain.Courses.Features;

using CourseManagement.Domain.Courses.Services;
using CourseManagement.Domain.Courses;
using CourseManagement.Domain.Courses.Dtos;
using CourseManagement.Domain.Courses.Models;
using CourseManagement.Services;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddCourse
{
    public sealed record Command(CourseForCreationDto CourseToAdd) : IRequest<CourseDto>;

    public sealed class Handler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, CourseDto>
    {
        public async Task<CourseDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var courseToAdd = request.CourseToAdd.ToCourseForCreation();
            var course = Course.Create(courseToAdd);

            await courseRepository.Add(course, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return course.ToCourseDto();
        }
    }
}