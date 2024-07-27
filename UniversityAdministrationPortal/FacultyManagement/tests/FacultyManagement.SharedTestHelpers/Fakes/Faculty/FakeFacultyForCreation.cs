namespace FacultyManagement.SharedTestHelpers.Fakes.Faculty;

using AutoBogus;
using FacultyManagement.Domain.Faculties;
using FacultyManagement.Domain.Faculties.Models;

public sealed class FakeFacultyForCreation : AutoFaker<FacultyForCreation>
{
    public FakeFacultyForCreation()
    {
    }
}