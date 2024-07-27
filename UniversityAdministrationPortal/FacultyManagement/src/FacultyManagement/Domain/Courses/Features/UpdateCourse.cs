namespace FacultyManagement.Domain.Courses.Features;

using FacultyManagement.Domain.Courses;
using FacultyManagement.Domain.Courses.Dtos;
using FacultyManagement.Domain.Courses.Services;
using FacultyManagement.Services;
using FacultyManagement.Domain.Courses.Models;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateCourse
{
    public sealed record Command(Guid CourseId, CourseForUpdateDto UpdatedCourseData) : IRequest;

    public sealed class Handler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var courseToUpdate = await courseRepository.GetById(request.CourseId, cancellationToken: cancellationToken);
            var courseToAdd = request.UpdatedCourseData.ToCourseForUpdate();
            courseToUpdate.Update(courseToAdd);

            courseRepository.Update(courseToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}