namespace CourseManagement.IntegrationTests.FeatureTests.Resources;

using CourseManagement.SharedTestHelpers.Fakes.Resource;
using CourseManagement.Domain.Resources.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class ResourceQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_resource_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var resourceOne = new FakeResourceBuilder().Build();
        await testingServiceScope.InsertAsync(resourceOne);

        // Act
        var query = new GetResource.Query(resourceOne.Id);
        var resource = await testingServiceScope.SendAsync(query);

        // Assert
        resource.ResourceName.Should().Be(resourceOne.ResourceName);
        resource.ResourceType.Should().Be(resourceOne.ResourceType);
        resource.Quantity.Should().Be(resourceOne.Quantity);
        resource.CourseID.Should().Be(resourceOne.CourseID);
    }

    [Fact]
    public async Task get_resource_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetResource.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}