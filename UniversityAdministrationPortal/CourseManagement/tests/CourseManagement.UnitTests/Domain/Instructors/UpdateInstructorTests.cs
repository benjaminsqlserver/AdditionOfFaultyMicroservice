namespace CourseManagement.UnitTests.Domain.Instructors;

using CourseManagement.SharedTestHelpers.Fakes.Instructor;
using CourseManagement.Domain.Instructors;
using CourseManagement.Domain.Instructors.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CourseManagement.Exceptions.ValidationException;

public class UpdateInstructorTests
{
    private readonly Faker _faker;

    public UpdateInstructorTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_instructor()
    {
        // Arrange
        var instructor = new FakeInstructorBuilder().Build();
        var updatedInstructor = new FakeInstructorForUpdate().Generate();
        
        // Act
        instructor.Update(updatedInstructor);

        // Assert
        instructor.FirstName.Should().Be(updatedInstructor.FirstName);
        instructor.LastName.Should().Be(updatedInstructor.LastName);
        instructor.Email.Should().Be(updatedInstructor.Email);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var instructor = new FakeInstructorBuilder().Build();
        var updatedInstructor = new FakeInstructorForUpdate().Generate();
        instructor.DomainEvents.Clear();
        
        // Act
        instructor.Update(updatedInstructor);

        // Assert
        instructor.DomainEvents.Count.Should().Be(1);
        instructor.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(InstructorUpdated));
    }
}