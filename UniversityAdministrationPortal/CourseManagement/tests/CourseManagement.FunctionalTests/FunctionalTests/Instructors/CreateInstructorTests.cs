namespace CourseManagement.FunctionalTests.FunctionalTests.Instructors;

using CourseManagement.SharedTestHelpers.Fakes.Instructor;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateInstructorTests : TestBase
{
    [Fact]
    public async Task create_instructor_returns_created_using_valid_dto()
    {
        // Arrange
        var instructor = new FakeInstructorForCreationDto().Generate();

        // Act
        var route = ApiRoutes.Instructors.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, instructor);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}