namespace CourseManagement.UnitTests.Domain.Resources;

using CourseManagement.SharedTestHelpers.Fakes.Resource;
using CourseManagement.Domain.Resources;
using CourseManagement.Domain.Resources.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CourseManagement.Exceptions.ValidationException;

public class CreateResourceTests
{
    private readonly Faker _faker;

    public CreateResourceTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_resource()
    {
        // Arrange
        var resourceToCreate = new FakeResourceForCreation().Generate();
        
        // Act
        var resource = Resource.Create(resourceToCreate);

        // Assert
        resource.ResourceName.Should().Be(resourceToCreate.ResourceName);
        resource.ResourceType.Should().Be(resourceToCreate.ResourceType);
        resource.Quantity.Should().Be(resourceToCreate.Quantity);
        resource.CourseID.Should().Be(resourceToCreate.CourseID);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var resourceToCreate = new FakeResourceForCreation().Generate();
        
        // Act
        var resource = Resource.Create(resourceToCreate);

        // Assert
        resource.DomainEvents.Count.Should().Be(1);
        resource.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(ResourceCreated));
    }
}