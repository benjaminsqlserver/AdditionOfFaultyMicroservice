namespace FacultyManagement.IntegrationTests.FeatureTests.Courses;

using FacultyManagement.SharedTestHelpers.Fakes.Course;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FacultyManagement.Domain.Courses.Features;

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
        courseReturned.CourseCode.Should().Be(courseOne.CourseCode);
        courseReturned.CourseName.Should().Be(courseOne.CourseName);
        courseReturned.Credits.Should().Be(courseOne.Credits);

        courseCreated.CourseCode.Should().Be(courseOne.CourseCode);
        courseCreated.CourseName.Should().Be(courseOne.CourseName);
        courseCreated.Credits.Should().Be(courseOne.Credits);
    }
}