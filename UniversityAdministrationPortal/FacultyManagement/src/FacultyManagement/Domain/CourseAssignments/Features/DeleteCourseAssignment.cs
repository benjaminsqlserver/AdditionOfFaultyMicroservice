namespace FacultyManagement.Domain.CourseAssignments.Features;

using FacultyManagement.Domain.CourseAssignments.Services;
using FacultyManagement.Services;
using FacultyManagement.Exceptions;
using MediatR;

public static class DeleteCourseAssignment
{
    public sealed record Command(Guid CourseAssignmentId) : IRequest;

    public sealed class Handler(ICourseAssignmentRepository courseAssignmentRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await courseAssignmentRepository.GetById(request.CourseAssignmentId, cancellationToken: cancellationToken);
            courseAssignmentRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}