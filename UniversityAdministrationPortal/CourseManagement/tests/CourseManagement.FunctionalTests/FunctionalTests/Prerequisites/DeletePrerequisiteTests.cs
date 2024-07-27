namespace CourseManagement.FunctionalTests.FunctionalTests.Prerequisites;

using CourseManagement.SharedTestHelpers.Fakes.Prerequisite;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeletePrerequisiteTests : TestBase
{
    [Fact]
    public async Task delete_prerequisite_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var prerequisite = new FakePrerequisiteBuilder().Build();
        await InsertAsync(prerequisite);

        // Act
        var route = ApiRoutes.Prerequisites.Delete(prerequisite.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}