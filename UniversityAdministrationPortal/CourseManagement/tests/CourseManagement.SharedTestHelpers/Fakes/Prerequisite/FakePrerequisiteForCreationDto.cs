namespace CourseManagement.SharedTestHelpers.Fakes.Prerequisite;

using AutoBogus;
using CourseManagement.Domain.Prerequisites;
using CourseManagement.Domain.Prerequisites.Dtos;

public sealed class FakePrerequisiteForCreationDto : AutoFaker<PrerequisiteForCreationDto>
{
    public FakePrerequisiteForCreationDto()
    {
    }
}