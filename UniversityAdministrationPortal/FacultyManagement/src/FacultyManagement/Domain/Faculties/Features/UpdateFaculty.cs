namespace FacultyManagement.Domain.Faculties.Features;

using FacultyManagement.Domain.Faculties;
using FacultyManagement.Domain.Faculties.Dtos;
using FacultyManagement.Domain.Faculties.Services;
using FacultyManagement.Services;
using FacultyManagement.Domain.Faculties.Models;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateFaculty
{
    public sealed record Command(Guid FacultyId, FacultyForUpdateDto UpdatedFacultyData) : IRequest;

    public sealed class Handler(IFacultyRepository facultyRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var facultyToUpdate = await facultyRepository.GetById(request.FacultyId, cancellationToken: cancellationToken);
            var facultyToAdd = request.UpdatedFacultyData.ToFacultyForUpdate();
            facultyToUpdate.Update(facultyToAdd);

            facultyRepository.Update(facultyToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}