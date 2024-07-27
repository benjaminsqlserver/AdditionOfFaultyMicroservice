namespace CourseManagement.IntegrationTests.FeatureTests.Resources;

using CourseManagement.SharedTestHelpers.Fakes.Resource;
using CourseManagement.Domain.Resources.Dtos;
using CourseManagement.Domain.Resources.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateResourceCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_resource_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var resource = new FakeResourceBuilder().Build();
        await testingServiceScope.InsertAsync(resource);
        var updatedResourceDto = new FakeResourceForUpdateDto().Generate();

        // Act
        var command = new UpdateResource.Command(resource.Id, updatedResourceDto);
        await testingServiceScope.SendAsync(command);
        var updatedResource = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Resources
                .FirstOrDefaultAsync(r => r.Id == resource.Id));

        // Assert
        updatedResource.ResourceName.Should().Be(updatedResourceDto.ResourceName);
        updatedResource.ResourceType.Should().Be(updatedResourceDto.ResourceType);
        updatedResource.Quantity.Should().Be(updatedResourceDto.Quantity);
        updatedResource.CourseID.Should().Be(updatedResourceDto.CourseID);
    }
}