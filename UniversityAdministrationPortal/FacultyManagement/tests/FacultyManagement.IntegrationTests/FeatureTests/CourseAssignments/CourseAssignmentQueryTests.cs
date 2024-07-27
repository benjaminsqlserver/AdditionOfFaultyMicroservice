namespace FacultyManagement.IntegrationTests.FeatureTests.CourseAssignments;

using FacultyManagement.SharedTestHelpers.Fakes.CourseAssignment;
using FacultyManagement.Domain.CourseAssignments.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class CourseAssignmentQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_courseassignment_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var courseAssignmentOne = new FakeCourseAssignmentBuilder().Build();
        await testingServiceScope.InsertAsync(courseAssignmentOne);

        // Act
        var query = new GetCourseAssignment.Query(courseAssignmentOne.Id);
        var courseAssignment = await testingServiceScope.SendAsync(query);

        // Assert
        courseAssignment.FacultyID.Should().Be(courseAssignmentOne.FacultyID);
        courseAssignment.CourseID.Should().Be(courseAssignmentOne.CourseID);
        courseAssignment.AssignmentDate.Should().BeCloseTo(courseAssignmentOne.AssignmentDate, 1.Seconds());
    }

    [Fact]
    public async Task get_courseassignment_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetCourseAssignment.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}