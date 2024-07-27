namespace FacultyManagement.IntegrationTests.FeatureTests.CourseAssignments;

using FacultyManagement.SharedTestHelpers.Fakes.CourseAssignment;
using FacultyManagement.Domain.CourseAssignments.Dtos;
using FacultyManagement.Domain.CourseAssignments.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateCourseAssignmentCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_courseassignment_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var courseAssignment = new FakeCourseAssignmentBuilder().Build();
        await testingServiceScope.InsertAsync(courseAssignment);
        var updatedCourseAssignmentDto = new FakeCourseAssignmentForUpdateDto().Generate();

        // Act
        var command = new UpdateCourseAssignment.Command(courseAssignment.Id, updatedCourseAssignmentDto);
        await testingServiceScope.SendAsync(command);
        var updatedCourseAssignment = await testingServiceScope
            .ExecuteDbContextAsync(db => db.CourseAssignments
                .FirstOrDefaultAsync(c => c.Id == courseAssignment.Id));

        // Assert
        updatedCourseAssignment.FacultyID.Should().Be(updatedCourseAssignmentDto.FacultyID);
        updatedCourseAssignment.CourseID.Should().Be(updatedCourseAssignmentDto.CourseID);
        updatedCourseAssignment.AssignmentDate.Should().BeCloseTo(updatedCourseAssignmentDto.AssignmentDate, 1.Seconds());
    }
}