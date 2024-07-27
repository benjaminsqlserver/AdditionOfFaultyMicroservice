namespace CourseManagement.FunctionalTests.FunctionalTests.Schedules;

using CourseManagement.SharedTestHelpers.Fakes.Schedule;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateScheduleTests : TestBase
{
    [Fact]
    public async Task create_schedule_returns_created_using_valid_dto()
    {
        // Arrange
        var schedule = new FakeScheduleForCreationDto().Generate();

        // Act
        var route = ApiRoutes.Schedules.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, schedule);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}