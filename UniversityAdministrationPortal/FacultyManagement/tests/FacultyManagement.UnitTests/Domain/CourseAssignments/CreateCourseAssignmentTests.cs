namespace FacultyManagement.UnitTests.Domain.CourseAssignments;

using FacultyManagement.SharedTestHelpers.Fakes.CourseAssignment;
using FacultyManagement.Domain.CourseAssignments;
using FacultyManagement.Domain.CourseAssignments.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = FacultyManagement.Exceptions.ValidationException;

public class CreateCourseAssignmentTests
{
    private readonly Faker _faker;

    public CreateCourseAssignmentTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_courseAssignment()
    {
        // Arrange
        var courseAssignmentToCreate = new FakeCourseAssignmentForCreation().Generate();
        
        // Act
        var courseAssignment = CourseAssignment.Create(courseAssignmentToCreate);

        // Assert
        courseAssignment.FacultyID.Should().Be(courseAssignmentToCreate.FacultyID);
        courseAssignment.CourseID.Should().Be(courseAssignmentToCreate.CourseID);
        courseAssignment.AssignmentDate.Should().BeCloseTo(courseAssignmentToCreate.AssignmentDate, 1.Seconds());
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var courseAssignmentToCreate = new FakeCourseAssignmentForCreation().Generate();
        
        // Act
        var courseAssignment = CourseAssignment.Create(courseAssignmentToCreate);

        // Assert
        courseAssignment.DomainEvents.Count.Should().Be(1);
        courseAssignment.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(CourseAssignmentCreated));
    }
}