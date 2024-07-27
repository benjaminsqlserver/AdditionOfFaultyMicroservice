namespace CourseManagement.IntegrationTests.FeatureTests.Schedules;

using CourseManagement.SharedTestHelpers.Fakes.Schedule;
using CourseManagement.Domain.Schedules.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteScheduleCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_schedule_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var schedule = new FakeScheduleBuilder().Build();
        await testingServiceScope.InsertAsync(schedule);

        // Act
        var command = new DeleteSchedule.Command(schedule.Id);
        await testingServiceScope.SendAsync(command);
        var scheduleResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Schedules
                .CountAsync(s => s.Id == schedule.Id));

        // Assert
        scheduleResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_schedule_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteSchedule.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_schedule_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var schedule = new FakeScheduleBuilder().Build();
        await testingServiceScope.InsertAsync(schedule);

        // Act
        var command = new DeleteSchedule.Command(schedule.Id);
        await testingServiceScope.SendAsync(command);
        var deletedSchedule = await testingServiceScope.ExecuteDbContextAsync(db => db.Schedules
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == schedule.Id));

        // Assert
        deletedSchedule?.IsDeleted.Should().BeTrue();
    }
}