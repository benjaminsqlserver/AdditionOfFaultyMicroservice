namespace CourseManagement.FunctionalTests.FunctionalTests.Prerequisites;

using CourseManagement.SharedTestHelpers.Fakes.Prerequisite;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreatePrerequisiteTests : TestBase
{
    [Fact]
    public async Task create_prerequisite_returns_created_using_valid_dto()
    {
        // Arrange
        var prerequisite = new FakePrerequisiteForCreationDto().Generate();

        // Act
        var route = ApiRoutes.Prerequisites.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, prerequisite);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}