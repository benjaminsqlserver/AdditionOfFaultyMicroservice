namespace CourseManagement.SharedTestHelpers.Fakes.Resource;

using AutoBogus;
using CourseManagement.Domain.Resources;
using CourseManagement.Domain.Resources.Dtos;

public sealed class FakeResourceForCreationDto : AutoFaker<ResourceForCreationDto>
{
    public FakeResourceForCreationDto()
    {
    }
}