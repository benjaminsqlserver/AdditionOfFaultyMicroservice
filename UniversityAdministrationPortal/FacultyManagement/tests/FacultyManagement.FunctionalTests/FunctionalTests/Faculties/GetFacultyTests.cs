namespace FacultyManagement.FunctionalTests.FunctionalTests.Faculties;

using FacultyManagement.SharedTestHelpers.Fakes.Faculty;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetFacultyTests : TestBase
{
    [Fact]
    public async Task get_faculty_returns_success_when_entity_exists()
    {
        // Arrange
        var faculty = new FakeFacultyBuilder().Build();
        await InsertAsync(faculty);

        // Act
        var route = ApiRoutes.Faculties.GetRecord(faculty.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}