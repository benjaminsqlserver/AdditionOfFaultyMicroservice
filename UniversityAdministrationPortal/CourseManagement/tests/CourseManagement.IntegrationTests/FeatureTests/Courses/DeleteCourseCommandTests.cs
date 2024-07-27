namespace CourseManagement.IntegrationTests.FeatureTests.Courses;

using CourseManagement.SharedTestHelpers.Fakes.Course;
using CourseManagement.Domain.Courses.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteCourseCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_course_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var course = new FakeCourseBuilder().Build();
        await testingServiceScope.InsertAsync(course);

        // Act
        var command = new DeleteCourse.Command(course.Id);
        await testingServiceScope.SendAsync(command);
        var courseResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Courses
                .CountAsync(c => c.Id == course.Id));

        // Assert
        courseResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_course_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteCourse.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_course_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var course = new FakeCourseBuilder().Build();
        await testingServiceScope.InsertAsync(course);

        // Act
        var command = new DeleteCourse.Command(course.Id);
        await testingServiceScope.SendAsync(command);
        var deletedCourse = await testingServiceScope.ExecuteDbContextAsync(db => db.Courses
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == course.Id));

        // Assert
        deletedCourse?.IsDeleted.Should().BeTrue();
    }
}