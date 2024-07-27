namespace CourseManagement.FunctionalTests.FunctionalTests.Prerequisites;

using CourseManagement.SharedTestHelpers.Fakes.Prerequisite;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdatePrerequisiteRecordTests : TestBase
{
    [Fact]
    public async Task put_prerequisite_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var prerequisite = new FakePrerequisiteBuilder().Build();
        var updatedPrerequisiteDto = new FakePrerequisiteForUpdateDto().Generate();
        await InsertAsync(prerequisite);

        // Act
        var route = ApiRoutes.Prerequisites.Put(prerequisite.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedPrerequisiteDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}