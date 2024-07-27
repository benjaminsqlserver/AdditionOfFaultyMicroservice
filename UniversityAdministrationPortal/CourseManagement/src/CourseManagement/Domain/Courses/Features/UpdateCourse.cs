namespace CourseManagement.Domain.Courses.Features;

using CourseManagement.Domain.Courses;
using CourseManagement.Domain.Courses.Dtos;
using CourseManagement.Domain.Courses.Services;
using CourseManagement.Services;
using CourseManagement.Domain.Courses.Models;
using CourseManagement.Exceptions;
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