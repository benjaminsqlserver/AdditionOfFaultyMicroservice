namespace CourseManagement.FunctionalTests.FunctionalTests.Courses;

using CourseManagement.SharedTestHelpers.Fakes.Course;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateCourseRecordTests : TestBase
{
    [Fact]
    public async Task put_course_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var course = new FakeCourseBuilder().Build();
        var updatedCourseDto = new FakeCourseForUpdateDto().Generate();
        await InsertAsync(course);

        // Act
        var route = ApiRoutes.Courses.Put(course.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedCourseDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}