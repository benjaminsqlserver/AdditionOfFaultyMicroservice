namespace CourseManagement.Domain.Enrollments.Features;

using CourseManagement.Domain.Enrollments.Dtos;
using CourseManagement.Domain.Enrollments.Services;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetEnrollment
{
    public sealed record Query(Guid EnrollmentId) : IRequest<EnrollmentDto>;

    public sealed class Handler(IEnrollmentRepository enrollmentRepository)
        : IRequestHandler<Query, EnrollmentDto>
    {
        public async Task<EnrollmentDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await enrollmentRepository.GetById(request.EnrollmentId, cancellationToken: cancellationToken);
            return result.ToEnrollmentDto();
        }
    }
}