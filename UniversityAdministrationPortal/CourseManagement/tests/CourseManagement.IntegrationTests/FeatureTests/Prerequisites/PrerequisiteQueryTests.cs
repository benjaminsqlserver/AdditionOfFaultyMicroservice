namespace CourseManagement.IntegrationTests.FeatureTests.Prerequisites;

using CourseManagement.SharedTestHelpers.Fakes.Prerequisite;
using CourseManagement.Domain.Prerequisites.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class PrerequisiteQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_prerequisite_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var prerequisiteOne = new FakePrerequisiteBuilder().Build();
        await testingServiceScope.InsertAsync(prerequisiteOne);

        // Act
        var query = new GetPrerequisite.Query(prerequisiteOne.Id);
        var prerequisite = await testingServiceScope.SendAsync(query);

        // Assert
        prerequisite.CourseID.Should().Be(prerequisiteOne.CourseID);
        prerequisite.PrerequisiteCourseID.Should().Be(prerequisiteOne.PrerequisiteCourseID);
    }

    [Fact]
    public async Task get_prerequisite_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetPrerequisite.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}