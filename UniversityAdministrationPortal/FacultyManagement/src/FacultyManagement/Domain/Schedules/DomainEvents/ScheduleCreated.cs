namespace FacultyManagement.Domain.Schedules.DomainEvents;

public sealed class ScheduleCreated : DomainEvent
{
    public Schedule Schedule { get; set; } 
}
            