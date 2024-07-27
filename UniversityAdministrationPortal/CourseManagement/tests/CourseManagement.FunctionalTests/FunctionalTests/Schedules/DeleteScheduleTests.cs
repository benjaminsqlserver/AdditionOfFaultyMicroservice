namespace CourseManagement.FunctionalTests.FunctionalTests.Schedules;

using CourseManagement.SharedTestHelpers.Fakes.Schedule;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteScheduleTests : TestBase
{
    [Fact]
    public async Task delete_schedule_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var schedule = new FakeScheduleBuilder().Build();
        await InsertAsync(schedule);

        // Act
        var route = ApiRoutes.Schedules.Delete(schedule.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}