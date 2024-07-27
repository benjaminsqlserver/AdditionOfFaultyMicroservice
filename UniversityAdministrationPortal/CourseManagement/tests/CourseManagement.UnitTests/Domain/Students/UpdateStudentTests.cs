namespace CourseManagement.UnitTests.Domain.Students;

using CourseManagement.SharedTestHelpers.Fakes.Student;
using CourseManagement.Domain.Students;
using CourseManagement.Domain.Students.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CourseManagement.Exceptions.ValidationException;

public class UpdateStudentTests
{
    private readonly Faker _faker;

    public UpdateStudentTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_student()
    {
        // Arrange
        var student = new FakeStudentBuilder().Build();
        var updatedStudent = new FakeStudentForUpdate().Generate();
        
        // Act
        student.Update(updatedStudent);

        // Assert
        student.FirstName.Should().Be(updatedStudent.FirstName);
        student.LastName.Should().Be(updatedStudent.LastName);
        student.Email.Should().Be(updatedStudent.Email);
        student.PhoneNumber.Should().Be(updatedStudent.PhoneNumber);
        student.MatriculationNumber.Should().Be(updatedStudent.MatriculationNumber);
        student.GenderId.Should().Be(updatedStudent.GenderId);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var student = new FakeStudentBuilder().Build();
        var updatedStudent = new FakeStudentForUpdate().Generate();
        student.DomainEvents.Clear();
        
        // Act
        student.Update(updatedStudent);

        // Assert
        student.DomainEvents.Count.Should().Be(1);
        student.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(StudentUpdated));
    }
}