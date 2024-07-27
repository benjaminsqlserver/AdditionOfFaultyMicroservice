namespace FacultyManagement.Domain.CourseAssignments;

using System.ComponentModel.DataAnnotations;
using FacultyManagement.Domain.Courses;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using FacultyManagement.Exceptions;
using FacultyManagement.Domain.CourseAssignments.Models;
using FacultyManagement.Domain.CourseAssignments.DomainEvents;


public class CourseAssignment : BaseEntity
{
    public Guid FacultyID { get; private set; }

    public Guid CourseID { get; private set; }

    public DateTime AssignmentDate { get; private set; }

    public Course Course { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static CourseAssignment Create(CourseAssignmentForCreation courseAssignmentForCreation)
    {
        var newCourseAssignment = new CourseAssignment();

        newCourseAssignment.FacultyID = courseAssignmentForCreation.FacultyID;
        newCourseAssignment.CourseID = courseAssignmentForCreation.CourseID;
        newCourseAssignment.AssignmentDate = courseAssignmentForCreation.AssignmentDate;

        newCourseAssignment.QueueDomainEvent(new CourseAssignmentCreated(){ CourseAssignment = newCourseAssignment });
        
        return newCourseAssignment;
    }

    public CourseAssignment Update(CourseAssignmentForUpdate courseAssignmentForUpdate)
    {
        FacultyID = courseAssignmentForUpdate.FacultyID;
        CourseID = courseAssignmentForUpdate.CourseID;
        AssignmentDate = courseAssignmentForUpdate.AssignmentDate;

        QueueDomainEvent(new CourseAssignmentUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected CourseAssignment() { } // For EF + Mocking
}
