namespace CourseManagement.FunctionalTests.FunctionalTests.Courses;

using CourseManagement.SharedTestHelpers.Fakes.Course;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateCourseTests : TestBase
{
    [Fact]
    public async Task create_course_returns_created_using_valid_dto()
    {
        // Arrange
        var course = new FakeCourseForCreationDto().Generate();

        // Act
        var route = ApiRoutes.Courses.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, course);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}