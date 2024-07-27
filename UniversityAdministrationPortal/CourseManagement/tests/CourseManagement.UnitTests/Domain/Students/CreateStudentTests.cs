namespace CourseManagement.UnitTests.Domain.Students;

using CourseManagement.SharedTestHelpers.Fakes.Student;
using CourseManagement.Domain.Students;
using CourseManagement.Domain.Students.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CourseManagement.Exceptions.ValidationException;

public class CreateStudentTests
{
    private readonly Faker _faker;

    public CreateStudentTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_student()
    {
        // Arrange
        var studentToCreate = new FakeStudentForCreation().Generate();
        
        // Act
        var student = Student.Create(studentToCreate);

        // Assert
        student.FirstName.Should().Be(studentToCreate.FirstName);
        student.LastName.Should().Be(studentToCreate.LastName);
        student.Email.Should().Be(studentToCreate.Email);
        student.PhoneNumber.Should().Be(studentToCreate.PhoneNumber);
        student.MatriculationNumber.Should().Be(studentToCreate.MatriculationNumber);
        student.GenderId.Should().Be(studentToCreate.GenderId);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var studentToCreate = new FakeStudentForCreation().Generate();
        
        // Act
        var student = Student.Create(studentToCreate);

        // Assert
        student.DomainEvents.Count.Should().Be(1);
        student.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(StudentCreated));
    }
}