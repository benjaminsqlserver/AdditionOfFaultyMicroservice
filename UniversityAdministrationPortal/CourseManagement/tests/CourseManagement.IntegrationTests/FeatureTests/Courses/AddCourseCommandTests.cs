namespace CourseManagement.IntegrationTests.FeatureTests.Courses;

using CourseManagement.SharedTestHelpers.Fakes.Course;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CourseManagement.Domain.Courses.Features;

public class AddCourseCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_course_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var courseOne = new FakeCourseForCreationDto().Generate();

        // Act
        var command = new AddCourse.Command(courseOne);
        var courseReturned = await testingServiceScope.SendAsync(command);
        var courseCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Courses
            .FirstOrDefaultAsync(c => c.Id == courseReturned.Id));

        // Assert
        courseReturned.CourseName.Should().Be(courseOne.CourseName);
        courseReturned.Syllabus.Should().Be(courseOne.Syllabus);
        courseReturned.Credits.Should().Be(courseOne.Credits);

        courseCreated.CourseName.Should().Be(courseOne.CourseName);
        courseCreated.Syllabus.Should().Be(courseOne.Syllabus);
        courseCreated.Credits.Should().Be(courseOne.Credits);
    }
}