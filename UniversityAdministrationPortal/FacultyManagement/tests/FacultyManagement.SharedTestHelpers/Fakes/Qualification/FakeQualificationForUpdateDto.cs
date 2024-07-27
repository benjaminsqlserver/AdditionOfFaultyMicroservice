namespace FacultyManagement.SharedTestHelpers.Fakes.Qualification;

using AutoBogus;
using FacultyManagement.Domain.Qualifications;
using FacultyManagement.Domain.Qualifications.Dtos;

public sealed class FakeQualificationForUpdateDto : AutoFaker<QualificationForUpdateDto>
{
    public FakeQualificationForUpdateDto()
    {
    }
}