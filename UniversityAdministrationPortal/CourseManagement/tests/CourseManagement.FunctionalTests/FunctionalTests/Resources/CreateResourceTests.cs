namespace CourseManagement.FunctionalTests.FunctionalTests.Resources;

using CourseManagement.SharedTestHelpers.Fakes.Resource;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateResourceTests : TestBase
{
    [Fact]
    public async Task create_resource_returns_created_using_valid_dto()
    {
        // Arrange
        var resource = new FakeResourceForCreationDto().Generate();

        // Act
        var route = ApiRoutes.Resources.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, resource);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}