namespace CourseManagement.FunctionalTests.FunctionalTests.Courses;

using CourseManagement.SharedTestHelpers.Fakes.Course;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetCourseTests : TestBase
{
    [Fact]
    public async Task get_course_returns_success_when_entity_exists()
    {
        // Arrange
        var course = new FakeCourseBuilder().Build();
        await InsertAsync(course);

        // Act
        var route = ApiRoutes.Courses.GetRecord(course.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}