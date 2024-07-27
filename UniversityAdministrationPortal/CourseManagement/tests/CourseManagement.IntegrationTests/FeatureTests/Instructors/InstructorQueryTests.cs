namespace CourseManagement.IntegrationTests.FeatureTests.Instructors;

using CourseManagement.SharedTestHelpers.Fakes.Instructor;
using CourseManagement.Domain.Instructors.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class InstructorQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_instructor_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var instructorOne = new FakeInstructorBuilder().Build();
        await testingServiceScope.InsertAsync(instructorOne);

        // Act
        var query = new GetInstructor.Query(instructorOne.Id);
        var instructor = await testingServiceScope.SendAsync(query);

        // Assert
        instructor.FirstName.Should().Be(instructorOne.FirstName);
        instructor.LastName.Should().Be(instructorOne.LastName);
        instructor.Email.Should().Be(instructorOne.Email);
    }

    [Fact]
    public async Task get_instructor_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetInstructor.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}