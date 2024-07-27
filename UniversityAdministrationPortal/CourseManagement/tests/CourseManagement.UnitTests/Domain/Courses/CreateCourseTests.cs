namespace CourseManagement.UnitTests.Domain.Courses;

using CourseManagement.SharedTestHelpers.Fakes.Course;
using CourseManagement.Domain.Courses;
using CourseManagement.Domain.Courses.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CourseManagement.Exceptions.ValidationException;

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
        course.CourseName.Should().Be(courseToCreate.CourseName);
        course.Syllabus.Should().Be(courseToCreate.Syllabus);
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