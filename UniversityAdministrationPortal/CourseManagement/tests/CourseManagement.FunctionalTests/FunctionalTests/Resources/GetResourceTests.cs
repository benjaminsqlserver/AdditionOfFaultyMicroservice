namespace CourseManagement.FunctionalTests.FunctionalTests.Resources;

using CourseManagement.SharedTestHelpers.Fakes.Resource;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetResourceTests : TestBase
{
    [Fact]
    public async Task get_resource_returns_success_when_entity_exists()
    {
        // Arrange
        var resource = new FakeResourceBuilder().Build();
        await InsertAsync(resource);

        // Act
        var route = ApiRoutes.Resources.GetRecord(resource.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}