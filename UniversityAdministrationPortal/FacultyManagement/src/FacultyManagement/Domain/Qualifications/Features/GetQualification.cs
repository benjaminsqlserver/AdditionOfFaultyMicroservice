namespace FacultyManagement.Domain.Qualifications.Features;

using FacultyManagement.Domain.Qualifications.Dtos;
using FacultyManagement.Domain.Qualifications.Services;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetQualification
{
    public sealed record Query(Guid QualificationId) : IRequest<QualificationDto>;

    public sealed class Handler(IQualificationRepository qualificationRepository)
        : IRequestHandler<Query, QualificationDto>
    {
        public async Task<QualificationDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await qualificationRepository.GetById(request.QualificationId, cancellationToken: cancellationToken);
            return result.ToQualificationDto();
        }
    }
}