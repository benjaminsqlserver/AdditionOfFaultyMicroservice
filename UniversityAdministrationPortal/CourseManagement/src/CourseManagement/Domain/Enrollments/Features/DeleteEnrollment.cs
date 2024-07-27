namespace CourseManagement.Domain.Enrollments.Features;

using CourseManagement.Domain.Enrollments.Services;
using CourseManagement.Services;
using CourseManagement.Exceptions;
using MediatR;

public static class DeleteEnrollment
{
    public sealed record Command(Guid EnrollmentId) : IRequest;

    public sealed class Handler(IEnrollmentRepository enrollmentRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await enrollmentRepository.GetById(request.EnrollmentId, cancellationToken: cancellationToken);
            enrollmentRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}