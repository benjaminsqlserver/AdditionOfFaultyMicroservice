namespace FacultyManagement.Domain.Courses;

using System.ComponentModel.DataAnnotations;
using FacultyManagement.Domain.CourseAssignments;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using FacultyManagement.Exceptions;
using FacultyManagement.Domain.Courses.Models;
using FacultyManagement.Domain.Courses.DomainEvents;
using FacultyManagement.Domain.CourseAssignments;
using FacultyManagement.Domain.CourseAssignments.Models;


public class Course : BaseEntity
{
    public string CourseCode { get; private set; }

    public string CourseName { get; private set; }

    public int Credits { get; private set; }

    private readonly List<CourseAssignment> _courseAssignments = new();
    public IReadOnlyCollection<CourseAssignment> CourseAssignments => _courseAssignments.AsReadOnly();

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Course Create(CourseForCreation courseForCreation)
    {
        var newCourse = new Course();

        newCourse.CourseCode = courseForCreation.CourseCode;
        newCourse.CourseName = courseForCreation.CourseName;
        newCourse.Credits = courseForCreation.Credits;

        newCourse.QueueDomainEvent(new CourseCreated(){ Course = newCourse });
        
        return newCourse;
    }

    public Course Update(CourseForUpdate courseForUpdate)
    {
        CourseCode = courseForUpdate.CourseCode;
        CourseName = courseForUpdate.CourseName;
        Credits = courseForUpdate.Credits;

        QueueDomainEvent(new CourseUpdated(){ Id = Id });
        return this;
    }

    public Course AddCourseAssignment(CourseAssignment courseAssignment)
    {
        _courseAssignments.Add(courseAssignment);
        return this;
    }
    
    public Course RemoveCourseAssignment(CourseAssignment courseAssignment)
    {
        _courseAssignments.RemoveAll(x => x.Id == courseAssignment.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Course() { } // For EF + Mocking
}
