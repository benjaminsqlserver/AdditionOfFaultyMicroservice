namespace CourseManagement.SharedTestHelpers.Fakes.Prerequisite;

using AutoBogus;
using CourseManagement.Domain.Prerequisites;
using CourseManagement.Domain.Prerequisites.Models;

public sealed class FakePrerequisiteForUpdate : AutoFaker<PrerequisiteForUpdate>
{
    public FakePrerequisiteForUpdate()
    {
    }
}