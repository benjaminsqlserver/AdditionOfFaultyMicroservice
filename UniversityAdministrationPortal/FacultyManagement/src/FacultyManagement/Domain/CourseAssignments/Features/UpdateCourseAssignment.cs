namespace FacultyManagement.Domain.CourseAssignments.Features;

using FacultyManagement.Domain.CourseAssignments;
using FacultyManagement.Domain.CourseAssignments.Dtos;
using FacultyManagement.Domain.CourseAssignments.Services;
using FacultyManagement.Services;
using FacultyManagement.Domain.CourseAssignments.Models;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateCourseAssignment
{
    public sealed record Command(Guid CourseAssignmentId, CourseAssignmentForUpdateDto UpdatedCourseAssignmentData) : IRequest;

    public sealed class Handler(ICourseAssignmentRepository courseAssignmentRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var courseAssignmentToUpdate = await courseAssignmentRepository.GetById(request.CourseAssignmentId, cancellationToken: cancellationToken);
            var courseAssignmentToAdd = request.UpdatedCourseAssignmentData.ToCourseAssignmentForUpdate();
            courseAssignmentToUpdate.Update(courseAssignmentToAdd);

            courseAssignmentRepository.Update(courseAssignmentToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}