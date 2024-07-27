namespace CourseManagement.IntegrationTests.FeatureTests.Enrollments;

using CourseManagement.Domain.Enrollments.Dtos;
using CourseManagement.SharedTestHelpers.Fakes.Enrollment;
using CourseManagement.Domain.Enrollments.Features;
using Domain;
using System.Threading.Tasks;

public class EnrollmentListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_enrollment_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var enrollmentOne = new FakeEnrollmentBuilder().Build();
        var enrollmentTwo = new FakeEnrollmentBuilder().Build();
        var queryParameters = new EnrollmentParametersDto();

        await testingServiceScope.InsertAsync(enrollmentOne, enrollmentTwo);

        // Act
        var query = new GetEnrollmentList.Query(queryParameters);
        var enrollments = await testingServiceScope.SendAsync(query);

        // Assert
        enrollments.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}