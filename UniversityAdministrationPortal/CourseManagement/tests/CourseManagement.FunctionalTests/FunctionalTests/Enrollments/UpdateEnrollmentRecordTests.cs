namespace CourseManagement.FunctionalTests.FunctionalTests.Enrollments;

using CourseManagement.SharedTestHelpers.Fakes.Enrollment;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateEnrollmentRecordTests : TestBase
{
    [Fact]
    public async Task put_enrollment_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var enrollment = new FakeEnrollmentBuilder().Build();
        var updatedEnrollmentDto = new FakeEnrollmentForUpdateDto().Generate();
        await InsertAsync(enrollment);

        // Act
        var route = ApiRoutes.Enrollments.Put(enrollment.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedEnrollmentDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}