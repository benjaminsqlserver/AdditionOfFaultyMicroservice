namespace FacultyManagement.IntegrationTests.FeatureTests.CourseAssignments;

using FacultyManagement.SharedTestHelpers.Fakes.CourseAssignment;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FacultyManagement.Domain.CourseAssignments.Features;

public class AddCourseAssignmentCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_courseassignment_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var courseAssignmentOne = new FakeCourseAssignmentForCreationDto().Generate();

        // Act
        var command = new AddCourseAssignment.Command(courseAssignmentOne);
        var courseAssignmentReturned = await testingServiceScope.SendAsync(command);
        var courseAssignmentCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.CourseAssignments
            .FirstOrDefaultAsync(c => c.Id == courseAssignmentReturned.Id));

        // Assert
        courseAssignmentReturned.FacultyID.Should().Be(courseAssignmentOne.FacultyID);
        courseAssignmentReturned.CourseID.Should().Be(courseAssignmentOne.CourseID);
        courseAssignmentReturned.AssignmentDate.Should().BeCloseTo(courseAssignmentOne.AssignmentDate, 1.Seconds());

        courseAssignmentCreated.FacultyID.Should().Be(courseAssignmentOne.FacultyID);
        courseAssignmentCreated.CourseID.Should().Be(courseAssignmentOne.CourseID);
        courseAssignmentCreated.AssignmentDate.Should().BeCloseTo(courseAssignmentOne.AssignmentDate, 1.Seconds());
    }
}