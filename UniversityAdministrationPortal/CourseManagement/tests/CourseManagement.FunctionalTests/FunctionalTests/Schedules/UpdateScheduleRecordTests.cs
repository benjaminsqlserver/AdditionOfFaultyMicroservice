namespace CourseManagement.FunctionalTests.FunctionalTests.Schedules;

using CourseManagement.SharedTestHelpers.Fakes.Schedule;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateScheduleRecordTests : TestBase
{
    [Fact]
    public async Task put_schedule_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var schedule = new FakeScheduleBuilder().Build();
        var updatedScheduleDto = new FakeScheduleForUpdateDto().Generate();
        await InsertAsync(schedule);

        // Act
        var route = ApiRoutes.Schedules.Put(schedule.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedScheduleDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}