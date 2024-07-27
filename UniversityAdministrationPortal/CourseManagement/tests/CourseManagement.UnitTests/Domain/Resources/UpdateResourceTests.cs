namespace CourseManagement.UnitTests.Domain.Resources;

using CourseManagement.SharedTestHelpers.Fakes.Resource;
using CourseManagement.Domain.Resources;
using CourseManagement.Domain.Resources.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CourseManagement.Exceptions.ValidationException;

public class UpdateResourceTests
{
    private readonly Faker _faker;

    public UpdateResourceTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_resource()
    {
        // Arrange
        var resource = new FakeResourceBuilder().Build();
        var updatedResource = new FakeResourceForUpdate().Generate();
        
        // Act
        resource.Update(updatedResource);

        // Assert
        resource.ResourceName.Should().Be(updatedResource.ResourceName);
        resource.ResourceType.Should().Be(updatedResource.ResourceType);
        resource.Quantity.Should().Be(updatedResource.Quantity);
        resource.CourseID.Should().Be(updatedResource.CourseID);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var resource = new FakeResourceBuilder().Build();
        var updatedResource = new FakeResourceForUpdate().Generate();
        resource.DomainEvents.Clear();
        
        // Act
        resource.Update(updatedResource);

        // Assert
        resource.DomainEvents.Count.Should().Be(1);
        resource.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(ResourceUpdated));
    }
}