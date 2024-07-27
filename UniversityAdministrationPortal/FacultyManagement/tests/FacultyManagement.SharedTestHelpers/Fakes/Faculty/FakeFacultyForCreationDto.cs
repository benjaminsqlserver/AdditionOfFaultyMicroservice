namespace FacultyManagement.SharedTestHelpers.Fakes.Faculty;

using AutoBogus;
using FacultyManagement.Domain.Faculties;
using FacultyManagement.Domain.Faculties.Dtos;

public sealed class FakeFacultyForCreationDto : AutoFaker<FacultyForCreationDto>
{
    public FakeFacultyForCreationDto()
    {
    }
}