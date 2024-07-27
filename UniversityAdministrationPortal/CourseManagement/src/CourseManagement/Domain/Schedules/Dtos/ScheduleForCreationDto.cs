namespace CourseManagement.Domain.Schedules.Dtos;

using Destructurama.Attributed;

public sealed record ScheduleForCreationDto
{
    public DateTime ClassTiming { get; set; }
    public string Location { get; set; }
    public Guid CourseID { get; set; }
    public Guid InstructorID { get; set; }
}
