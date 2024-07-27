namespace CourseManagement.Domain.Enrollments.Features;

using CourseManagement.Domain.Enrollments;
using CourseManagement.Domain.Enrollments.Dtos;
using CourseManagement.Domain.Enrollments.Services;
using CourseManagement.Services;
using CourseManagement.Domain.Enrollments.Models;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateEnrollment
{
    public sealed record Command(Guid EnrollmentId, EnrollmentForUpdateDto UpdatedEnrollmentData) : IRequest;

    public sealed class Handler(IEnrollmentRepository enrollmentRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var enrollmentToUpdate = await enrollmentRepository.GetById(request.EnrollmentId, cancellationToken: cancellationToken);
            var enrollmentToAdd = request.UpdatedEnrollmentData.ToEnrollmentForUpdate();
            enrollmentToUpdate.Update(enrollmentToAdd);

            enrollmentRepository.Update(enrollmentToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}