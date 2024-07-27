namespace CourseManagement.UnitTests.Domain.Instructors;

using CourseManagement.SharedTestHelpers.Fakes.Instructor;
using CourseManagement.Domain.Instructors;
using CourseManagement.Domain.Instructors.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CourseManagement.Exceptions.ValidationException;

public class CreateInstructorTests
{
    private readonly Faker _faker;

    public CreateInstructorTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_instructor()
    {
        // Arrange
        var instructorToCreate = new FakeInstructorForCreation().Generate();
        
        // Act
        var instructor = Instructor.Create(instructorToCreate);

        // Assert
        instructor.FirstName.Should().Be(instructorToCreate.FirstName);
        instructor.LastName.Should().Be(instructorToCreate.LastName);
        instructor.Email.Should().Be(instructorToCreate.Email);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var instructorToCreate = new FakeInstructorForCreation().Generate();
        
        // Act
        var instructor = Instructor.Create(instructorToCreate);

        // Assert
        instructor.DomainEvents.Count.Should().Be(1);
        instructor.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(InstructorCreated));
    }
}