namespace CourseManagement.FunctionalTests.FunctionalTests.Schedules;

using CourseManagement.SharedTestHelpers.Fakes.Schedule;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetScheduleTests : TestBase
{
    [Fact]
    public async Task get_schedule_returns_success_when_entity_exists()
    {
        // Arrange
        var schedule = new FakeScheduleBuilder().Build();
        await InsertAsync(schedule);

        // Act
        var route = ApiRoutes.Schedules.GetRecord(schedule.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}