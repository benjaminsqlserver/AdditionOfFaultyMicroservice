namespace CourseManagement.UnitTests.Domain.Courses;

using CourseManagement.SharedTestHelpers.Fakes.Course;
using CourseManagement.Domain.Courses;
using CourseManagement.Domain.Courses.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CourseManagement.Exceptions.ValidationException;

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
        course.CourseName.Should().Be(updatedCourse.CourseName);
        course.Syllabus.Should().Be(updatedCourse.Syllabus);
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