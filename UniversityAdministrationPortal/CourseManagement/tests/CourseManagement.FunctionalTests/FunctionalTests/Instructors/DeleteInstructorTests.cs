namespace CourseManagement.FunctionalTests.FunctionalTests.Instructors;

using CourseManagement.SharedTestHelpers.Fakes.Instructor;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteInstructorTests : TestBase
{
    [Fact]
    public async Task delete_instructor_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var instructor = new FakeInstructorBuilder().Build();
        await InsertAsync(instructor);

        // Act
        var route = ApiRoutes.Instructors.Delete(instructor.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}