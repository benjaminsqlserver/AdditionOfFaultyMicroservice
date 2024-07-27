namespace CourseManagement.SharedTestHelpers.Fakes.Resource;

using CourseManagement.Domain.Resources;
using CourseManagement.Domain.Resources.Models;

public class FakeResourceBuilder
{
    private ResourceForCreation _creationData = new FakeResourceForCreation().Generate();

    public FakeResourceBuilder WithModel(ResourceForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeResourceBuilder WithResourceName(string resourceName)
    {
        _creationData.ResourceName = resourceName;
        return this;
    }
    
    public FakeResourceBuilder WithResourceType(string resourceType)
    {
        _creationData.ResourceType = resourceType;
        return this;
    }
    
    public FakeResourceBuilder WithQuantity(int quantity)
    {
        _creationData.Quantity = quantity;
        return this;
    }
    
    public FakeResourceBuilder WithCourseID(Guid courseID)
    {
        _creationData.CourseID = courseID;
        return this;
    }
    
    public Resource Build()
    {
        var result = Resource.Create(_creationData);
        return result;
    }
}