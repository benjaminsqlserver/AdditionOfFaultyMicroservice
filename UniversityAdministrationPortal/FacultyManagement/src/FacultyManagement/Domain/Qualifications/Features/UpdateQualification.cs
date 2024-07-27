namespace FacultyManagement.Domain.Qualifications.Features;

using FacultyManagement.Domain.Qualifications;
using FacultyManagement.Domain.Qualifications.Dtos;
using FacultyManagement.Domain.Qualifications.Services;
using FacultyManagement.Services;
using FacultyManagement.Domain.Qualifications.Models;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateQualification
{
    public sealed record Command(Guid QualificationId, QualificationForUpdateDto UpdatedQualificationData) : IRequest;

    public sealed class Handler(IQualificationRepository qualificationRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var qualificationToUpdate = await qualificationRepository.GetById(request.QualificationId, cancellationToken: cancellationToken);
            var qualificationToAdd = request.UpdatedQualificationData.ToQualificationForUpdate();
            qualificationToUpdate.Update(qualificationToAdd);

            qualificationRepository.Update(qualificationToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}