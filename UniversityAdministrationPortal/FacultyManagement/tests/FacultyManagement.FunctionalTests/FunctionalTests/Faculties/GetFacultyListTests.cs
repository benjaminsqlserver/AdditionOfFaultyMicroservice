namespace FacultyManagement.FunctionalTests.FunctionalTests.Faculties;

using FacultyManagement.SharedTestHelpers.Fakes.Faculty;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetFacultyListTests : TestBase
{
    [Fact]
    public async Task get_faculty_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Faculties.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}