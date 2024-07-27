namespace FacultyManagement.Domain.Qualifications.Features;

using FacultyManagement.Domain.Qualifications.Services;
using FacultyManagement.Domain.Qualifications;
using FacultyManagement.Domain.Qualifications.Dtos;
using FacultyManagement.Domain.Qualifications.Models;
using FacultyManagement.Services;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddQualification
{
    public sealed record Command(QualificationForCreationDto QualificationToAdd) : IRequest<QualificationDto>;

    public sealed class Handler(IQualificationRepository qualificationRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, QualificationDto>
    {
        public async Task<QualificationDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var qualificationToAdd = request.QualificationToAdd.ToQualificationForCreation();
            var qualification = Qualification.Create(qualificationToAdd);

            await qualificationRepository.Add(qualification, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return qualification.ToQualificationDto();
        }
    }
}