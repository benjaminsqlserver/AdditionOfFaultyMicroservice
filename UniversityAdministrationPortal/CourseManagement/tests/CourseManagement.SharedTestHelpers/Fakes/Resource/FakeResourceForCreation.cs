namespace CourseManagement.SharedTestHelpers.Fakes.Resource;

using AutoBogus;
using CourseManagement.Domain.Resources;
using CourseManagement.Domain.Resources.Models;

public sealed class FakeResourceForCreation : AutoFaker<ResourceForCreation>
{
    public FakeResourceForCreation()
    {
    }
}