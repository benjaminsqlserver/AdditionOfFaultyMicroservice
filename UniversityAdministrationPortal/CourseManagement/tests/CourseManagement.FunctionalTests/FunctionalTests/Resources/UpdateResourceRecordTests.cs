namespace CourseManagement.FunctionalTests.FunctionalTests.Resources;

using CourseManagement.SharedTestHelpers.Fakes.Resource;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateResourceRecordTests : TestBase
{
    [Fact]
    public async Task put_resource_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var resource = new FakeResourceBuilder().Build();
        var updatedResourceDto = new FakeResourceForUpdateDto().Generate();
        await InsertAsync(resource);

        // Act
        var route = ApiRoutes.Resources.Put(resource.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedResourceDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}