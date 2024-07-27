namespace CourseManagement.FunctionalTests.FunctionalTests.Instructors;

using CourseManagement.SharedTestHelpers.Fakes.Instructor;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateInstructorRecordTests : TestBase
{
    [Fact]
    public async Task put_instructor_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var instructor = new FakeInstructorBuilder().Build();
        var updatedInstructorDto = new FakeInstructorForUpdateDto().Generate();
        await InsertAsync(instructor);

        // Act
        var route = ApiRoutes.Instructors.Put(instructor.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedInstructorDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}