namespace CourseManagement.FunctionalTests.FunctionalTests.Resources;

using CourseManagement.SharedTestHelpers.Fakes.Resource;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetResourceListTests : TestBase
{
    [Fact]
    public async Task get_resource_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Resources.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}