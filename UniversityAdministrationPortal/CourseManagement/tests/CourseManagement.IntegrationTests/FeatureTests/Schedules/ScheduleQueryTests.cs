namespace CourseManagement.IntegrationTests.FeatureTests.Schedules;

using CourseManagement.SharedTestHelpers.Fakes.Schedule;
using CourseManagement.Domain.Schedules.Features;
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
        schedule.ClassTiming.Should().BeCloseTo(scheduleOne.ClassTiming, 1.Seconds());
        schedule.Location.Should().Be(scheduleOne.Location);
        schedule.CourseID.Should().Be(scheduleOne.CourseID);
        schedule.InstructorID.Should().Be(scheduleOne.InstructorID);
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