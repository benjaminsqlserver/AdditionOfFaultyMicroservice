namespace CourseManagement.FunctionalTests.FunctionalTests.Instructors;

using CourseManagement.SharedTestHelpers.Fakes.Instructor;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetInstructorTests : TestBase
{
    [Fact]
    public async Task get_instructor_returns_success_when_entity_exists()
    {
        // Arrange
        var instructor = new FakeInstructorBuilder().Build();
        await InsertAsync(instructor);

        // Act
        var route = ApiRoutes.Instructors.GetRecord(instructor.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}