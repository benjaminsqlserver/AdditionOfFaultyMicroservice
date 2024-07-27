namespace FacultyManagement.IntegrationTests.FeatureTests.CourseAssignments;

using FacultyManagement.Domain.CourseAssignments.Dtos;
using FacultyManagement.SharedTestHelpers.Fakes.CourseAssignment;
using FacultyManagement.Domain.CourseAssignments.Features;
using Domain;
using System.Threading.Tasks;

public class CourseAssignmentListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_courseassignment_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var courseAssignmentOne = new FakeCourseAssignmentBuilder().Build();
        var courseAssignmentTwo = new FakeCourseAssignmentBuilder().Build();
        var queryParameters = new CourseAssignmentParametersDto();

        await testingServiceScope.InsertAsync(courseAssignmentOne, courseAssignmentTwo);

        // Act
        var query = new GetCourseAssignmentList.Query(queryParameters);
        var courseAssignments = await testingServiceScope.SendAsync(query);

        // Assert
        courseAssignments.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}