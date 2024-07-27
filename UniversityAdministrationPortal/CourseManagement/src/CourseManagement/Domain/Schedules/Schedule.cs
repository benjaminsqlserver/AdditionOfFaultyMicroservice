namespace CourseManagement.Domain.Schedules;

using System.ComponentModel.DataAnnotations;
using CourseManagement.Domain.LectureHalls;
using CourseManagement.Domain.Instructors;
using CourseManagement.Domain.Courses;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using CourseManagement.Exceptions;
using CourseManagement.Domain.Schedules.Models;
using CourseManagement.Domain.Schedules.DomainEvents;


public class Schedule : BaseEntity
{
    public DateTime ClassTiming { get; private set; }

    public string Location { get; private set; }

    public Guid CourseID { get; private set; }

    public Guid InstructorID { get; private set; }

    public Course Course { get; }

    public Instructor Instructor { get; }

    public LectureHall LectureHall { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Schedule Create(ScheduleForCreation scheduleForCreation)
    {
        var newSchedule = new Schedule();

        newSchedule.ClassTiming = scheduleForCreation.ClassTiming;
        newSchedule.Location = scheduleForCreation.Location;
        newSchedule.CourseID = scheduleForCreation.CourseID;
        newSchedule.InstructorID = scheduleForCreation.InstructorID;

        newSchedule.QueueDomainEvent(new ScheduleCreated(){ Schedule = newSchedule });
        
        return newSchedule;
    }

    public Schedule Update(ScheduleForUpdate scheduleForUpdate)
    {
        ClassTiming = scheduleForUpdate.ClassTiming;
        Location = scheduleForUpdate.Location;
        CourseID = scheduleForUpdate.CourseID;
        InstructorID = scheduleForUpdate.InstructorID;

        QueueDomainEvent(new ScheduleUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Schedule() { } // For EF + Mocking
}
