namespace FacultyManagement.FunctionalTests.FunctionalTests.CourseAssignments;

using FacultyManagement.SharedTestHelpers.Fakes.CourseAssignment;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteCourseAssignmentTests : TestBase
{
    [Fact]
    public async Task delete_courseassignment_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var courseAssignment = new FakeCourseAssignmentBuilder().Build();
        await InsertAsync(courseAssignment);

        // Act
        var route = ApiRoutes.CourseAssignments.Delete(courseAssignment.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}