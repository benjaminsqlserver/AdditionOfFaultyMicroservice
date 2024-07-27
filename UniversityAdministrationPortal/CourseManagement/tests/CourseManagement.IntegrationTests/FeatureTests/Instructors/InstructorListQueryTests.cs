namespace CourseManagement.IntegrationTests.FeatureTests.Instructors;

using CourseManagement.Domain.Instructors.Dtos;
using CourseManagement.SharedTestHelpers.Fakes.Instructor;
using CourseManagement.Domain.Instructors.Features;
using Domain;
using System.Threading.Tasks;

public class InstructorListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_instructor_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var instructorOne = new FakeInstructorBuilder().Build();
        var instructorTwo = new FakeInstructorBuilder().Build();
        var queryParameters = new InstructorParametersDto();

        await testingServiceScope.InsertAsync(instructorOne, instructorTwo);

        // Act
        var query = new GetInstructorList.Query(queryParameters);
        var instructors = await testingServiceScope.SendAsync(query);

        // Assert
        instructors.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}