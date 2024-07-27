namespace CourseManagement.IntegrationTests.FeatureTests.Courses;

using CourseManagement.Domain.Courses.Dtos;
using CourseManagement.SharedTestHelpers.Fakes.Course;
using CourseManagement.Domain.Courses.Features;
using Domain;
using System.Threading.Tasks;

public class CourseListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_course_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var courseOne = new FakeCourseBuilder().Build();
        var courseTwo = new FakeCourseBuilder().Build();
        var queryParameters = new CourseParametersDto();

        await testingServiceScope.InsertAsync(courseOne, courseTwo);

        // Act
        var query = new GetCourseList.Query(queryParameters);
        var courses = await testingServiceScope.SendAsync(query);

        // Assert
        courses.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}