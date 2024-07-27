namespace FacultyManagement.FunctionalTests.FunctionalTests.Qualifications;

using FacultyManagement.SharedTestHelpers.Fakes.Qualification;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateQualificationTests : TestBase
{
    [Fact]
    public async Task create_qualification_returns_created_using_valid_dto()
    {
        // Arrange
        var qualification = new FakeQualificationForCreationDto().Generate();

        // Act
        var route = ApiRoutes.Qualifications.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, qualification);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}