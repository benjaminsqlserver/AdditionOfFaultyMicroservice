namespace FacultyManagement.FunctionalTests.FunctionalTests.Courses;

using FacultyManagement.SharedTestHelpers.Fakes.Course;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetCourseListTests : TestBase
{
    [Fact]
    public async Task get_course_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Courses.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}