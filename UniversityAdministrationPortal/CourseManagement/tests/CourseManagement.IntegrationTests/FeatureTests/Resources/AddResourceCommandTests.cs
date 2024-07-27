namespace CourseManagement.IntegrationTests.FeatureTests.Resources;

using CourseManagement.SharedTestHelpers.Fakes.Resource;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CourseManagement.Domain.Resources.Features;

public class AddResourceCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_resource_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var resourceOne = new FakeResourceForCreationDto().Generate();

        // Act
        var command = new AddResource.Command(resourceOne);
        var resourceReturned = await testingServiceScope.SendAsync(command);
        var resourceCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Resources
            .FirstOrDefaultAsync(r => r.Id == resourceReturned.Id));

        // Assert
        resourceReturned.ResourceName.Should().Be(resourceOne.ResourceName);
        resourceReturned.ResourceType.Should().Be(resourceOne.ResourceType);
        resourceReturned.Quantity.Should().Be(resourceOne.Quantity);
        resourceReturned.CourseID.Should().Be(resourceOne.CourseID);

        resourceCreated.ResourceName.Should().Be(resourceOne.ResourceName);
        resourceCreated.ResourceType.Should().Be(resourceOne.ResourceType);
        resourceCreated.Quantity.Should().Be(resourceOne.Quantity);
        resourceCreated.CourseID.Should().Be(resourceOne.CourseID);
    }
}