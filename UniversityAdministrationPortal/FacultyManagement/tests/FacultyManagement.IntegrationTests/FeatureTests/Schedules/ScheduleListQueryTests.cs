namespace FacultyManagement.IntegrationTests.FeatureTests.Schedules;

using FacultyManagement.Domain.Schedules.Dtos;
using FacultyManagement.SharedTestHelpers.Fakes.Schedule;
using FacultyManagement.Domain.Schedules.Features;
using Domain;
using System.Threading.Tasks;

public class ScheduleListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_schedule_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var scheduleOne = new FakeScheduleBuilder().Build();
        var scheduleTwo = new FakeScheduleBuilder().Build();
        var queryParameters = new ScheduleParametersDto();

        await testingServiceScope.InsertAsync(scheduleOne, scheduleTwo);

        // Act
        var query = new GetScheduleList.Query(queryParameters);
        var schedules = await testingServiceScope.SendAsync(query);

        // Assert
        schedules.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}