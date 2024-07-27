namespace FacultyManagement.IntegrationTests.FeatureTests.Schedules;

using FacultyManagement.SharedTestHelpers.Fakes.Schedule;
using FacultyManagement.Domain.Schedules.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class ScheduleQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_schedule_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var scheduleOne = new FakeScheduleBuilder().Build();
        await testingServiceScope.InsertAsync(scheduleOne);

        // Act
        var query = new GetSchedule.Query(scheduleOne.Id);
        var schedule = await testingServiceScope.SendAsync(query);

        // Assert
        schedule.FacultyID.Should().Be(scheduleOne.FacultyID);
        schedule.DayOfWeek.Should().Be(scheduleOne.DayOfWeek);
        schedule.StartTime.Should().BeCloseTo(scheduleOne.StartTime, 1.Seconds());
        schedule.EndTime.Should().BeCloseTo(scheduleOne.EndTime, 1.Seconds());
        schedule.IsOfficeHour.Should().Be(scheduleOne.IsOfficeHour);
    }

    [Fact]
    public async Task get_schedule_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetSchedule.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}