namespace FacultyManagement.FunctionalTests.FunctionalTests.CourseAssignments;

using FacultyManagement.SharedTestHelpers.Fakes.CourseAssignment;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetCourseAssignmentListTests : TestBase
{
    [Fact]
    public async Task get_courseassignment_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.CourseAssignments.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}