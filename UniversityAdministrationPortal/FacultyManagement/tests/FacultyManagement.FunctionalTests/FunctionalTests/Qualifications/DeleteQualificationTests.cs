namespace FacultyManagement.FunctionalTests.FunctionalTests.Qualifications;

using FacultyManagement.SharedTestHelpers.Fakes.Qualification;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteQualificationTests : TestBase
{
    [Fact]
    public async Task delete_qualification_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var qualification = new FakeQualificationBuilder().Build();
        await InsertAsync(qualification);

        // Act
        var route = ApiRoutes.Qualifications.Delete(qualification.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}