namespace FacultyManagement.IntegrationTests.FeatureTests.Courses;

using FacultyManagement.SharedTestHelpers.Fakes.Course;
using FacultyManagement.Domain.Courses.Dtos;
using FacultyManagement.Domain.Courses.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateCourseCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_course_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var course = new FakeCourseBuilder().Build();
        await testingServiceScope.InsertAsync(course);
        var updatedCourseDto = new FakeCourseForUpdateDto().Generate();

        // Act
        var command = new UpdateCourse.Command(course.Id, updatedCourseDto);
        await testingServiceScope.SendAsync(command);
        var updatedCourse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Courses
                .FirstOrDefaultAsync(c => c.Id == course.Id));

        // Assert
        updatedCourse.CourseCode.Should().Be(updatedCourseDto.CourseCode);
        updatedCourse.CourseName.Should().Be(updatedCourseDto.CourseName);
        updatedCourse.Credits.Should().Be(updatedCourseDto.Credits);
    }
}