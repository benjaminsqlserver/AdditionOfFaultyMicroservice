namespace FacultyManagement.FunctionalTests.FunctionalTests.CourseAssignments;

using FacultyManagement.SharedTestHelpers.Fakes.CourseAssignment;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetCourseAssignmentTests : TestBase
{
    [Fact]
    public async Task get_courseassignment_returns_success_when_entity_exists()
    {
        // Arrange
        var courseAssignment = new FakeCourseAssignmentBuilder().Build();
        await InsertAsync(courseAssignment);

        // Act
        var route = ApiRoutes.CourseAssignments.GetRecord(courseAssignment.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}