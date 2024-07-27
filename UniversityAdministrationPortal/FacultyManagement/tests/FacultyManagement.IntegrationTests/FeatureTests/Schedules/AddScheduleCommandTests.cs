namespace FacultyManagement.IntegrationTests.FeatureTests.Schedules;

using FacultyManagement.SharedTestHelpers.Fakes.Schedule;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FacultyManagement.Domain.Schedules.Features;

public class AddScheduleCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_schedule_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var scheduleOne = new FakeScheduleForCreationDto().Generate();

        // Act
        var command = new AddSchedule.Command(scheduleOne);
        var scheduleReturned = await testingServiceScope.SendAsync(command);
        var scheduleCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Schedules
            .FirstOrDefaultAsync(s => s.Id == scheduleReturned.Id));

        // Assert
        scheduleReturned.FacultyID.Should().Be(scheduleOne.FacultyID);
        scheduleReturned.DayOfWeek.Should().Be(scheduleOne.DayOfWeek);
        scheduleReturned.StartTime.Should().BeCloseTo(scheduleOne.StartTime, 1.Seconds());
        scheduleReturned.EndTime.Should().BeCloseTo(scheduleOne.EndTime, 1.Seconds());
        scheduleReturned.IsOfficeHour.Should().Be(scheduleOne.IsOfficeHour);

        scheduleCreated.FacultyID.Should().Be(scheduleOne.FacultyID);
        scheduleCreated.DayOfWeek.Should().Be(scheduleOne.DayOfWeek);
        scheduleCreated.StartTime.Should().BeCloseTo(scheduleOne.StartTime, 1.Seconds());
        scheduleCreated.EndTime.Should().BeCloseTo(scheduleOne.EndTime, 1.Seconds());
        scheduleCreated.IsOfficeHour.Should().Be(scheduleOne.IsOfficeHour);
    }
}