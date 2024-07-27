namespace CourseManagement.Domain.Resources;

using System.ComponentModel.DataAnnotations;
using CourseManagement.Domain.Courses;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using CourseManagement.Exceptions;
using CourseManagement.Domain.Resources.Models;
using CourseManagement.Domain.Resources.DomainEvents;


public class Resource : BaseEntity
{
    public string ResourceName { get; private set; }

    public string ResourceType { get; private set; }

    public int Quantity { get; private set; }

    public Guid CourseID { get; private set; }

    public Course Course { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Resource Create(ResourceForCreation resourceForCreation)
    {
        var newResource = new Resource();

        newResource.ResourceName = resourceForCreation.ResourceName;
        newResource.ResourceType = resourceForCreation.ResourceType;
        newResource.Quantity = resourceForCreation.Quantity;
        newResource.CourseID = resourceForCreation.CourseID;

        newResource.QueueDomainEvent(new ResourceCreated(){ Resource = newResource });
        
        return newResource;
    }

    public Resource Update(ResourceForUpdate resourceForUpdate)
    {
        ResourceName = resourceForUpdate.ResourceName;
        ResourceType = resourceForUpdate.ResourceType;
        Quantity = resourceForUpdate.Quantity;
        CourseID = resourceForUpdate.CourseID;

        QueueDomainEvent(new ResourceUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Resource() { } // For EF + Mocking
}
