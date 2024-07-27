namespace FacultyManagement.FunctionalTests.FunctionalTests.Courses;

using FacultyManagement.SharedTestHelpers.Fakes.Course;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteCourseTests : TestBase
{
    [Fact]
    public async Task delete_course_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var course = new FakeCourseBuilder().Build();
        await InsertAsync(course);

        // Act
        var route = ApiRoutes.Courses.Delete(course.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}