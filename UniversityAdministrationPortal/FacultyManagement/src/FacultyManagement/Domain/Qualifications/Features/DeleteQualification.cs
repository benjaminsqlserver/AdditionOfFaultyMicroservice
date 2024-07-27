namespace FacultyManagement.Domain.Qualifications.Features;

using FacultyManagement.Domain.Qualifications.Services;
using FacultyManagement.Services;
using FacultyManagement.Exceptions;
using MediatR;

public static class DeleteQualification
{
    public sealed record Command(Guid QualificationId) : IRequest;

    public sealed class Handler(IQualificationRepository qualificationRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await qualificationRepository.GetById(request.QualificationId, cancellationToken: cancellationToken);
            qualificationRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}