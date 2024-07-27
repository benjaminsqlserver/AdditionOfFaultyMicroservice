namespace FacultyManagement.UnitTests.Domain.CourseAssignments;

using FacultyManagement.SharedTestHelpers.Fakes.CourseAssignment;
using FacultyManagement.Domain.CourseAssignments;
using FacultyManagement.Domain.CourseAssignments.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = FacultyManagement.Exceptions.ValidationException;

public class UpdateCourseAssignmentTests
{
    private readonly Faker _faker;

    public UpdateCourseAssignmentTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_courseAssignment()
    {
        // Arrange
        var courseAssignment = new FakeCourseAssignmentBuilder().Build();
        var updatedCourseAssignment = new FakeCourseAssignmentForUpdate().Generate();
        
        // Act
        courseAssignment.Update(updatedCourseAssignment);

        // Assert
        courseAssignment.FacultyID.Should().Be(updatedCourseAssignment.FacultyID);
        courseAssignment.CourseID.Should().Be(updatedCourseAssignment.CourseID);
        courseAssignment.AssignmentDate.Should().BeCloseTo(updatedCourseAssignment.AssignmentDate, 1.Seconds());
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var courseAssignment = new FakeCourseAssignmentBuilder().Build();
        var updatedCourseAssignment = new FakeCourseAssignmentForUpdate().Generate();
        courseAssignment.DomainEvents.Clear();
        
        // Act
        courseAssignment.Update(updatedCourseAssignment);

        // Assert
        courseAssignment.DomainEvents.Count.Should().Be(1);
        courseAssignment.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(CourseAssignmentUpdated));
    }
}