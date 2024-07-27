namespace CourseManagement.Domain.Enrollments;

using System.ComponentModel.DataAnnotations;
using CourseManagement.Domain.Students;
using CourseManagement.Domain.Courses;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using CourseManagement.Exceptions;
using CourseManagement.Domain.Enrollments.Models;
using CourseManagement.Domain.Enrollments.DomainEvents;


public class Enrollment : BaseEntity
{
    public DateTime EnrollmentDate { get; private set; }

    public Guid StudentID { get; private set; }

    public Guid CourseID { get; private set; }

    public Course Course { get; }

    public Student Student { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Enrollment Create(EnrollmentForCreation enrollmentForCreation)
    {
        var newEnrollment = new Enrollment();

        newEnrollment.EnrollmentDate = enrollmentForCreation.EnrollmentDate;
        newEnrollment.StudentID = enrollmentForCreation.StudentID;
        newEnrollment.CourseID = enrollmentForCreation.CourseID;

        newEnrollment.QueueDomainEvent(new EnrollmentCreated(){ Enrollment = newEnrollment });
        
        return newEnrollment;
    }

    public Enrollment Update(EnrollmentForUpdate enrollmentForUpdate)
    {
        EnrollmentDate = enrollmentForUpdate.EnrollmentDate;
        StudentID = enrollmentForUpdate.StudentID;
        CourseID = enrollmentForUpdate.CourseID;

        QueueDomainEvent(new EnrollmentUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Enrollment() { } // For EF + Mocking
}
