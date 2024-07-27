namespace FacultyManagement.FunctionalTests.FunctionalTests.Faculties;

using FacultyManagement.SharedTestHelpers.Fakes.Faculty;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateFacultyTests : TestBase
{
    [Fact]
    public async Task create_faculty_returns_created_using_valid_dto()
    {
        // Arrange
        var faculty = new FakeFacultyForCreationDto().Generate();

        // Act
        var route = ApiRoutes.Faculties.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, faculty);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}