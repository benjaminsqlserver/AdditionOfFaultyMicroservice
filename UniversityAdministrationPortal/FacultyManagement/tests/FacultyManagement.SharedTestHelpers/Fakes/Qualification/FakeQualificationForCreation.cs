namespace FacultyManagement.SharedTestHelpers.Fakes.Qualification;

using AutoBogus;
using FacultyManagement.Domain.Qualifications;
using FacultyManagement.Domain.Qualifications.Models;

public sealed class FakeQualificationForCreation : AutoFaker<QualificationForCreation>
{
    public FakeQualificationForCreation()
    {
    }
}