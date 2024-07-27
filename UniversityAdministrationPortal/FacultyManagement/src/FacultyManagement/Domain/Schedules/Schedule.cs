namespace FacultyManagement.Domain.Schedules;

using System.ComponentModel.DataAnnotations;
using FacultyManagement.Domain.Faculties;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using FacultyManagement.Exceptions;
using FacultyManagement.Domain.Schedules.Models;
using FacultyManagement.Domain.Schedules.DomainEvents;


public class Schedule : BaseEntity
{
    public Guid FacultyID { get; private set; }

    public string DayOfWeek { get; private set; }

    public DateTime StartTime { get; private set; }

    public DateTime EndTime { get; private set; }

    public bool IsOfficeHour { get; private set; }

    public Faculty Faculty { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Schedule Create(ScheduleForCreation scheduleForCreation)
    {
        var newSchedule = new Schedule();

        newSchedule.FacultyID = scheduleForCreation.FacultyID;
        newSchedule.DayOfWeek = scheduleForCreation.DayOfWeek;
        newSchedule.StartTime = scheduleForCreation.StartTime;
        newSchedule.EndTime = scheduleForCreation.EndTime;
        newSchedule.IsOfficeHour = scheduleForCreation.IsOfficeHour;

        newSchedule.QueueDomainEvent(new ScheduleCreated(){ Schedule = newSchedule });
        
        return newSchedule;
    }

    public Schedule Update(ScheduleForUpdate scheduleForUpdate)
    {
        FacultyID = scheduleForUpdate.FacultyID;
        DayOfWeek = scheduleForUpdate.DayOfWeek;
        StartTime = scheduleForUpdate.StartTime;
        EndTime = scheduleForUpdate.EndTime;
        IsOfficeHour = scheduleForUpdate.IsOfficeHour;

        QueueDomainEvent(new ScheduleUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Schedule() { } // For EF + Mocking
}
