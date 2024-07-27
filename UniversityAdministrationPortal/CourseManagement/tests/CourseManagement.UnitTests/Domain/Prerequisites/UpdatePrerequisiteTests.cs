namespace CourseManagement.UnitTests.Domain.Prerequisites;

using CourseManagement.SharedTestHelpers.Fakes.Prerequisite;
using CourseManagement.Domain.Prerequisites;
using CourseManagement.Domain.Prerequisites.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CourseManagement.Exceptions.ValidationException;

public class UpdatePrerequisiteTests
{
    private readonly Faker _faker;

    public UpdatePrerequisiteTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_prerequisite()
    {
        // Arrange
        var prerequisite = new FakePrerequisiteBuilder().Build();
        var updatedPrerequisite = new FakePrerequisiteForUpdate().Generate();
        
        // Act
        prerequisite.Update(updatedPrerequisite);

        // Assert
        prerequisite.CourseID.Should().Be(updatedPrerequisite.CourseID);
        prerequisite.PrerequisiteCourseID.Should().Be(updatedPrerequisite.PrerequisiteCourseID);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var prerequisite = new FakePrerequisiteBuilder().Build();
        var updatedPrerequisite = new FakePrerequisiteForUpdate().Generate();
        prerequisite.DomainEvents.Clear();
        
        // Act
        prerequisite.Update(updatedPrerequisite);

        // Assert
        prerequisite.DomainEvents.Count.Should().Be(1);
        prerequisite.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(PrerequisiteUpdated));
    }
}