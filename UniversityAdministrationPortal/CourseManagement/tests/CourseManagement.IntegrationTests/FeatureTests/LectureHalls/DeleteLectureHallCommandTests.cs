namespace CourseManagement.IntegrationTests.FeatureTests.LectureHalls;

using CourseManagement.SharedTestHelpers.Fakes.LectureHall;
using CourseManagement.Domain.LectureHalls.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteLectureHallCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_lecturehall_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var lectureHall = new FakeLectureHallBuilder().Build();
        await testingServiceScope.InsertAsync(lectureHall);

        // Act
        var command = new DeleteLectureHall.Command(lectureHall.Id);
        await testingServiceScope.SendAsync(command);
        var lectureHallResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.LectureHalls
                .CountAsync(l => l.Id == lectureHall.Id));

        // Assert
        lectureHallResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_lecturehall_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteLectureHall.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_lecturehall_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var lectureHall = new FakeLectureHallBuilder().Build();
        await testingServiceScope.InsertAsync(lectureHall);

        // Act
        var command = new DeleteLectureHall.Command(lectureHall.Id);
        await testingServiceScope.SendAsync(command);
        var deletedLectureHall = await testingServiceScope.ExecuteDbContextAsync(db => db.LectureHalls
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == lectureHall.Id));

        // Assert
        deletedLectureHall?.IsDeleted.Should().BeTrue();
    }
}