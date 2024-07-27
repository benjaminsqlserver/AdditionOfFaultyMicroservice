namespace CourseManagement.UnitTests.Domain.Prerequisites;

using CourseManagement.SharedTestHelpers.Fakes.Prerequisite;
using CourseManagement.Domain.Prerequisites;
using CourseManagement.Domain.Prerequisites.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CourseManagement.Exceptions.ValidationException;

public class CreatePrerequisiteTests
{
    private readonly Faker _faker;

    public CreatePrerequisiteTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_prerequisite()
    {
        // Arrange
        var prerequisiteToCreate = new FakePrerequisiteForCreation().Generate();
        
        // Act
        var prerequisite = Prerequisite.Create(prerequisiteToCreate);

        // Assert
        prerequisite.CourseID.Should().Be(prerequisiteToCreate.CourseID);
        prerequisite.PrerequisiteCourseID.Should().Be(prerequisiteToCreate.PrerequisiteCourseID);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var prerequisiteToCreate = new FakePrerequisiteForCreation().Generate();
        
        // Act
        var prerequisite = Prerequisite.Create(prerequisiteToCreate);

        // Assert
        prerequisite.DomainEvents.Count.Should().Be(1);
        prerequisite.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(PrerequisiteCreated));
    }
}