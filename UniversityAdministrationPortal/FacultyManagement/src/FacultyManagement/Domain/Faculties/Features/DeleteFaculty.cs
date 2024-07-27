namespace FacultyManagement.Domain.Faculties.Features;

using FacultyManagement.Domain.Faculties.Services;
using FacultyManagement.Services;
using FacultyManagement.Exceptions;
using MediatR;

public static class DeleteFaculty
{
    public sealed record Command(Guid FacultyId) : IRequest;

    public sealed class Handler(IFacultyRepository facultyRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await facultyRepository.GetById(request.FacultyId, cancellationToken: cancellationToken);
            facultyRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}