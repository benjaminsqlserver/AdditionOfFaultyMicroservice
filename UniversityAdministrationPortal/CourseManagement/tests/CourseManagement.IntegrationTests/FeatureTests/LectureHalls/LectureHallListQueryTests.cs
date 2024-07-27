namespace CourseManagement.IntegrationTests.FeatureTests.LectureHalls;

using CourseManagement.Domain.LectureHalls.Dtos;
using CourseManagement.SharedTestHelpers.Fakes.LectureHall;
using CourseManagement.Domain.LectureHalls.Features;
using Domain;
using System.Threading.Tasks;

public class LectureHallListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_lecturehall_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var lectureHallOne = new FakeLectureHallBuilder().Build();
        var lectureHallTwo = new FakeLectureHallBuilder().Build();
        var queryParameters = new LectureHallParametersDto();

        await testingServiceScope.InsertAsync(lectureHallOne, lectureHallTwo);

        // Act
        var query = new GetLectureHallList.Query(queryParameters);
        var lectureHalls = await testingServiceScope.SendAsync(query);

        // Assert
        lectureHalls.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}