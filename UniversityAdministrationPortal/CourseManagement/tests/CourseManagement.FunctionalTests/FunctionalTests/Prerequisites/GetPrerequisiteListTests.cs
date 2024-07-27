namespace CourseManagement.FunctionalTests.FunctionalTests.Prerequisites;

using CourseManagement.SharedTestHelpers.Fakes.Prerequisite;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetPrerequisiteListTests : TestBase
{
    [Fact]
    public async Task get_prerequisite_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Prerequisites.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}