namespace CourseManagement.IntegrationTests.FeatureTests.Courses;

using CourseManagement.SharedTestHelpers.Fakes.Course;
using CourseManagement.Domain.Courses.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class CourseQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_course_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var courseOne = new FakeCourseBuilder().Build();
        await testingServiceScope.InsertAsync(courseOne);

        // Act
        var query = new GetCourse.Query(courseOne.Id);
        var course = await testingServiceScope.SendAsync(query);

        // Assert
        course.CourseName.Should().Be(courseOne.CourseName);
        course.Syllabus.Should().Be(courseOne.Syllabus);
        course.Credits.Should().Be(courseOne.Credits);
    }

    [Fact]
    public async Task get_course_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetCourse.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}