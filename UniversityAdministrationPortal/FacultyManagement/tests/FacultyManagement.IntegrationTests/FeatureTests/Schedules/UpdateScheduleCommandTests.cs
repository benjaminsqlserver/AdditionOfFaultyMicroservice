namespace FacultyManagement.IntegrationTests.FeatureTests.Schedules;

using FacultyManagement.SharedTestHelpers.Fakes.Schedule;
using FacultyManagement.Domain.Schedules.Dtos;
using FacultyManagement.Domain.Schedules.Features;
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
        updatedSchedule.FacultyID.Should().Be(updatedScheduleDto.FacultyID);
        updatedSchedule.DayOfWeek.Should().Be(updatedScheduleDto.DayOfWeek);
        updatedSchedule.StartTime.Should().BeCloseTo(updatedScheduleDto.StartTime, 1.Seconds());
        updatedSchedule.EndTime.Should().BeCloseTo(updatedScheduleDto.EndTime, 1.Seconds());
        updatedSchedule.IsOfficeHour.Should().Be(updatedScheduleDto.IsOfficeHour);
    }
}