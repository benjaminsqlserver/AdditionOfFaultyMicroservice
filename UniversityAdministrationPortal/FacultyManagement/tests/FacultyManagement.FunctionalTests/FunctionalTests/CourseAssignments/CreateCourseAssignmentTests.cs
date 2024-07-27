namespace FacultyManagement.FunctionalTests.FunctionalTests.CourseAssignments;

using FacultyManagement.SharedTestHelpers.Fakes.CourseAssignment;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateCourseAssignmentTests : TestBase
{
    [Fact]
    public async Task create_courseassignment_returns_created_using_valid_dto()
    {
        // Arrange
        var courseAssignment = new FakeCourseAssignmentForCreationDto().Generate();

        // Act
        var route = ApiRoutes.CourseAssignments.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, courseAssignment);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}