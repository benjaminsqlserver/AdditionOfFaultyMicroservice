namespace CourseManagement.FunctionalTests.FunctionalTests.Prerequisites;

using CourseManagement.SharedTestHelpers.Fakes.Prerequisite;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetPrerequisiteTests : TestBase
{
    [Fact]
    public async Task get_prerequisite_returns_success_when_entity_exists()
    {
        // Arrange
        var prerequisite = new FakePrerequisiteBuilder().Build();
        await InsertAsync(prerequisite);

        // Act
        var route = ApiRoutes.Prerequisites.GetRecord(prerequisite.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}