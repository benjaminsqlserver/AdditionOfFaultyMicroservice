namespace CourseManagement.IntegrationTests.FeatureTests.Schedules;

using CourseManagement.SharedTestHelpers.Fakes.Schedule;
using CourseManagement.Domain.Schedules.Dtos;
using CourseManagement.Domain.Schedules.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateScheduleCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_schedule_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var schedule = new FakeScheduleBuilder().Build();
        await testingServiceScope.InsertAsync(schedule);
        var updatedScheduleDto = new FakeScheduleForUpdateDto().Generate();

        // Act
        var command = new UpdateSchedule.Command(schedule.Id, updatedScheduleDto);
        await testingServiceScope.SendAsync(command);
        var updatedSchedule = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Schedules
                .FirstOrDefaultAsync(s => s.Id == schedule.Id));

        // Assert
        updatedSchedule.ClassTiming.Should().BeCloseTo(updatedScheduleDto.ClassTiming, 1.Seconds());
        updatedSchedule.Location.Should().Be(updatedScheduleDto.Location);
        updatedSchedule.CourseID.Should().Be(updatedScheduleDto.CourseID);
        updatedSchedule.InstructorID.Should().Be(updatedScheduleDto.InstructorID);
    }
}