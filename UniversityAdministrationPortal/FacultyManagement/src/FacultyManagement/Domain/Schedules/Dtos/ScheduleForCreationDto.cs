namespace FacultyManagement.Domain.Schedules.Dtos;

using Destructurama.Attributed;

public sealed record ScheduleForCreationDto
{
    public Guid FacultyID { get; set; }
    public string DayOfWeek { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsOfficeHour { get; set; }
}
