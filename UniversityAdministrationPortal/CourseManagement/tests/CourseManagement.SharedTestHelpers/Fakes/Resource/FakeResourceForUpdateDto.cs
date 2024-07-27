namespace CourseManagement.SharedTestHelpers.Fakes.Resource;

using AutoBogus;
using CourseManagement.Domain.Resources;
using CourseManagement.Domain.Resources.Dtos;

public sealed class FakeResourceForUpdateDto : AutoFaker<ResourceForUpdateDto>
{
    public FakeResourceForUpdateDto()
    {
    }
}