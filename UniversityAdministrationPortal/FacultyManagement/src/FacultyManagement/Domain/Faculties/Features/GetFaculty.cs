namespace FacultyManagement.Domain.Faculties.Features;

using FacultyManagement.Domain.Faculties.Dtos;
using FacultyManagement.Domain.Faculties.Services;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetFaculty
{
    public sealed record Query(Guid FacultyId) : IRequest<FacultyDto>;

    public sealed class Handler(IFacultyRepository facultyRepository)
        : IRequestHandler<Query, FacultyDto>
    {
        public async Task<FacultyDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await facultyRepository.GetById(request.FacultyId, cancellationToken: cancellationToken);
            return result.ToFacultyDto();
        }
    }
}