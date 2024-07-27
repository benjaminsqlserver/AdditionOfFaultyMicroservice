namespace FacultyManagement.Domain.Courses.Features;

using FacultyManagement.Domain.Courses.Services;
using FacultyManagement.Domain.Courses;
using FacultyManagement.Domain.Courses.Dtos;
using FacultyManagement.Domain.Courses.Models;
using FacultyManagement.Services;
using FacultyManagement.Exceptions;
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