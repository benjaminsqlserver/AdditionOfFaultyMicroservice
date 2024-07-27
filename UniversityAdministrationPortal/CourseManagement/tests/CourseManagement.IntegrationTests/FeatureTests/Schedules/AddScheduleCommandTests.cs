namespace CourseManagement.IntegrationTests.FeatureTests.Schedules;

using CourseManagement.SharedTestHelpers.Fakes.Schedule;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CourseManagement.Domain.Schedules.Features;

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
        scheduleReturned.ClassTiming.Should().BeCloseTo(scheduleOne.ClassTiming, 1.Seconds());
        scheduleReturned.Location.Should().Be(scheduleOne.Location);
        scheduleReturned.CourseID.Should().Be(scheduleOne.CourseID);
        scheduleReturned.InstructorID.Should().Be(scheduleOne.InstructorID);

        scheduleCreated.ClassTiming.Should().BeCloseTo(scheduleOne.ClassTiming, 1.Seconds());
        scheduleCreated.Location.Should().Be(scheduleOne.Location);
        scheduleCreated.CourseID.Should().Be(scheduleOne.CourseID);
        scheduleCreated.InstructorID.Should().Be(scheduleOne.InstructorID);
    }
}