namespace FacultyManagement.UnitTests.Domain.Schedules;

using FacultyManagement.SharedTestHelpers.Fakes.Schedule;
using FacultyManagement.Domain.Schedules;
using FacultyManagement.Domain.Schedules.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = FacultyManagement.Exceptions.ValidationException;

public class UpdateScheduleTests
{
    private readonly Faker _faker;

    public UpdateScheduleTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_schedule()
    {
        // Arrange
        var schedule = new FakeScheduleBuilder().Build();
        var updatedSchedule = new FakeScheduleForUpdate().Generate();
        
        // Act
        schedule.Update(updatedSchedule);

        // Assert
        schedule.FacultyID.Should().Be(updatedSchedule.FacultyID);
        schedule.DayOfWeek.Should().Be(updatedSchedule.DayOfWeek);
        schedule.StartTime.Should().BeCloseTo(updatedSchedule.StartTime, 1.Seconds());
        schedule.EndTime.Should().BeCloseTo(updatedSchedule.EndTime, 1.Seconds());
        schedule.IsOfficeHour.Should().Be(updatedSchedule.IsOfficeHour);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var schedule = new FakeScheduleBuilder().Build();
        var updatedSchedule = new FakeScheduleForUpdate().Generate();
        schedule.DomainEvents.Clear();
        
        // Act
        schedule.Update(updatedSchedule);

        // Assert
        schedule.DomainEvents.Count.Should().Be(1);
        schedule.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(ScheduleUpdated));
    }
}