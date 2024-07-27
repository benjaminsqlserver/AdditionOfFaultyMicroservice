namespace FacultyManagement.FunctionalTests.FunctionalTests.CourseAssignments;

using FacultyManagement.SharedTestHelpers.Fakes.CourseAssignment;
using FacultyManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateCourseAssignmentRecordTests : TestBase
{
    [Fact]
    public async Task put_courseassignment_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var courseAssignment = new FakeCourseAssignmentBuilder().Build();
        var updatedCourseAssignmentDto = new FakeCourseAssignmentForUpdateDto().Generate();
        await InsertAsync(courseAssignment);

        // Act
        var route = ApiRoutes.CourseAssignments.Put(courseAssignment.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedCourseAssignmentDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}