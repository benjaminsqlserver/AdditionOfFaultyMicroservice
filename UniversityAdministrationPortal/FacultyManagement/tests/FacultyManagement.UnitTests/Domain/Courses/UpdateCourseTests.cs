namespace FacultyManagement.UnitTests.Domain.Courses;

using FacultyManagement.SharedTestHelpers.Fakes.Course;
using FacultyManagement.Domain.Courses;
using FacultyManagement.Domain.Courses.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = FacultyManagement.Exceptions.ValidationException;

public class UpdateCourseTests
{
    private readonly Faker _faker;

    public UpdateCourseTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_course()
    {
        // Arrange
        var course = new FakeCourseBuilder().Build();
        var updatedCourse = new FakeCourseForUpdate().Generate();
        
        // Act
        course.Update(updatedCourse);

        // Assert
        course.CourseCode.Should().Be(updatedCourse.CourseCode);
        course.CourseName.Should().Be(updatedCourse.CourseName);
        course.Credits.Should().Be(updatedCourse.Credits);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var course = new FakeCourseBuilder().Build();
        var updatedCourse = new FakeCourseForUpdate().Generate();
        course.DomainEvents.Clear();
        
        // Act
        course.Update(updatedCourse);

        // Assert
        course.DomainEvents.Count.Should().Be(1);
        course.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(CourseUpdated));
    }
}