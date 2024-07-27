namespace FacultyManagement.Domain.Faculties.Features;

using FacultyManagement.Domain.Faculties.Services;
using FacultyManagement.Domain.Faculties;
using FacultyManagement.Domain.Faculties.Dtos;
using FacultyManagement.Domain.Faculties.Models;
using FacultyManagement.Services;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddFaculty
{
    public sealed record Command(FacultyForCreationDto FacultyToAdd) : IRequest<FacultyDto>;

    public sealed class Handler(IFacultyRepository facultyRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, FacultyDto>
    {
        public async Task<FacultyDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var facultyToAdd = request.FacultyToAdd.ToFacultyForCreation();
            var faculty = Faculty.Create(facultyToAdd);

            await facultyRepository.Add(faculty, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return faculty.ToFacultyDto();
        }
    }
}