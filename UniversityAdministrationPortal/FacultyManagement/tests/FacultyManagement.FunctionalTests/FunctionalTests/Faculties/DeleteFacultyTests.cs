namespace FacultyManagement.FunctionalTests.FunctionalTests.Faculties;

using FacultyManagement.SharedTestHelpers.Fakes.Faculty;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteFacultyTests : TestBase
{
    [Fact]
    public async Task delete_faculty_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var faculty = new FakeFacultyBuilder().Build();
        await InsertAsync(faculty);

        // Act
        var route = ApiRoutes.Faculties.Delete(faculty.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}