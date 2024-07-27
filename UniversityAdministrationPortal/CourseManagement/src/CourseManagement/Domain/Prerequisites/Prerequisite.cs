namespace CourseManagement.Domain.Prerequisites;

using System.ComponentModel.DataAnnotations;
using CourseManagement.Domain.Courses;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using CourseManagement.Exceptions;
using CourseManagement.Domain.Prerequisites.Models;
using CourseManagement.Domain.Prerequisites.DomainEvents;


public class Prerequisite : BaseEntity
{
    public Guid CourseID { get; private set; }

    public Guid PrerequisiteCourseID { get; private set; }

    public Course Course { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Prerequisite Create(PrerequisiteForCreation prerequisiteForCreation)
    {
        var newPrerequisite = new Prerequisite();

        newPrerequisite.CourseID = prerequisiteForCreation.CourseID;
        newPrerequisite.PrerequisiteCourseID = prerequisiteForCreation.PrerequisiteCourseID;

        newPrerequisite.QueueDomainEvent(new PrerequisiteCreated(){ Prerequisite = newPrerequisite });
        
        return newPrerequisite;
    }

    public Prerequisite Update(PrerequisiteForUpdate prerequisiteForUpdate)
    {
        CourseID = prerequisiteForUpdate.CourseID;
        PrerequisiteCourseID = prerequisiteForUpdate.PrerequisiteCourseID;

        QueueDomainEvent(new PrerequisiteUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Prerequisite() { } // For EF + Mocking
}
