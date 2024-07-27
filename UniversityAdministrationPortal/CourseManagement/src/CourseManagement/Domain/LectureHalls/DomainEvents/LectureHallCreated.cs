namespace CourseManagement.Domain.LectureHalls.DomainEvents;

public sealed class LectureHallCreated : DomainEvent
{
    public LectureHall LectureHall { get; set; } 
}
            