namespace FacultyManagement.UnitTests.Domain.Courses;

using FacultyManagement.SharedTestHelpers.Fakes.Course;
using FacultyManagement.Domain.Courses;
using FacultyManagement.Domain.Courses.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = FacultyManagement.Exceptions.ValidationException;

public class CreateCourseTests
{
    private readonly Faker _faker;

    public CreateCourseTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_course()
    {
        // Arrange
        var courseToCreate = new FakeCourseForCreation().Generate();
        
        // Act
        var course = Course.Create(courseToCreate);

        // Assert
        course.CourseCode.Should().Be(courseToCreate.CourseCode);
        course.CourseName.Should().Be(courseToCreate.CourseName);
        course.Credits.Should().Be(courseToCreate.Credits);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var courseToCreate = new FakeCourseForCreation().Generate();
        
        // Act
        var course = Course.Create(courseToCreate);

        // Assert
        course.DomainEvents.Count.Should().Be(1);
        course.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(CourseCreated));
    }
}