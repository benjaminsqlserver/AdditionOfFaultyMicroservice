namespace FacultyManagement.FunctionalTests.FunctionalTests.Faculties;

using FacultyManagement.SharedTestHelpers.Fakes.Faculty;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateFacultyRecordTests : TestBase
{
    [Fact]
    public async Task put_faculty_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var faculty = new FakeFacultyBuilder().Build();
        var updatedFacultyDto = new FakeFacultyForUpdateDto().Generate();
        await InsertAsync(faculty);

        // Act
        var route = ApiRoutes.Faculties.Put(faculty.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedFacultyDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}