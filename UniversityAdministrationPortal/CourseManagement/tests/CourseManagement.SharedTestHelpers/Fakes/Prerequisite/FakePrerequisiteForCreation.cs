namespace CourseManagement.SharedTestHelpers.Fakes.Prerequisite;

using AutoBogus;
using CourseManagement.Domain.Prerequisites;
using CourseManagement.Domain.Prerequisites.Models;

public sealed class FakePrerequisiteForCreation : AutoFaker<PrerequisiteForCreation>
{
    public FakePrerequisiteForCreation()
    {
    }
}