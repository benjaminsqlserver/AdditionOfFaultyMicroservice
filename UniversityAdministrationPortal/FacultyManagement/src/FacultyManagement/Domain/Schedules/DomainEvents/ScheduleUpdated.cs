namespace FacultyManagement.Domain.Schedules.DomainEvents;

public sealed class ScheduleUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            