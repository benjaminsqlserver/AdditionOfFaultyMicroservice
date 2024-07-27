namespace CourseManagement.Domain.LectureHalls.DomainEvents;

public sealed class LectureHallUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            