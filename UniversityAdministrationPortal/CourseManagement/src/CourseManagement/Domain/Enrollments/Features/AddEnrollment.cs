namespace CourseManagement.Domain.Enrollments.Features;

using CourseManagement.Domain.Enrollments.Services;
using CourseManagement.Domain.Enrollments;
using CourseManagement.Domain.Enrollments.Dtos;
using CourseManagement.Domain.Enrollments.Models;
using CourseManagement.Services;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddEnrollment
{
    public sealed record Command(EnrollmentForCreationDto EnrollmentToAdd) : IRequest<EnrollmentDto>;

    public sealed class Handler(IEnrollmentRepository enrollmentRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, EnrollmentDto>
    {
        public async Task<EnrollmentDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var enrollmentToAdd = request.EnrollmentToAdd.ToEnrollmentForCreation();
            var enrollment = Enrollment.Create(enrollmentToAdd);

            await enrollmentRepository.Add(enrollment, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return enrollment.ToEnrollmentDto();
        }
    }
}