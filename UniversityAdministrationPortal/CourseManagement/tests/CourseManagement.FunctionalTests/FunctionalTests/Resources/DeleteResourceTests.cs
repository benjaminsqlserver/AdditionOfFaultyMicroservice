namespace CourseManagement.FunctionalTests.FunctionalTests.Resources;

using CourseManagement.SharedTestHelpers.Fakes.Resource;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteResourceTests : TestBase
{
    [Fact]
    public async Task delete_resource_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var resource = new FakeResourceBuilder().Build();
        await InsertAsync(resource);

        // Act
        var route = ApiRoutes.Resources.Delete(resource.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}