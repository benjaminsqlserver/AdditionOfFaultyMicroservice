namespace CourseManagement.IntegrationTests.FeatureTests.Resources;

using CourseManagement.SharedTestHelpers.Fakes.Resource;
using CourseManagement.Domain.Resources.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteResourceCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_resource_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var resource = new FakeResourceBuilder().Build();
        await testingServiceScope.InsertAsync(resource);

        // Act
        var command = new DeleteResource.Command(resource.Id);
        await testingServiceScope.SendAsync(command);
        var resourceResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Resources
                .CountAsync(r => r.Id == resource.Id));

        // Assert
        resourceResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_resource_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteResource.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_resource_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var resource = new FakeResourceBuilder().Build();
        await testingServiceScope.InsertAsync(resource);

        // Act
        var command = new DeleteResource.Command(resource.Id);
        await testingServiceScope.SendAsync(command);
        var deletedResource = await testingServiceScope.ExecuteDbContextAsync(db => db.Resources
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == resource.Id));

        // Assert
        deletedResource?.IsDeleted.Should().BeTrue();
    }
}