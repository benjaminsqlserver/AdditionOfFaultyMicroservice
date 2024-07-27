namespace FacultyManagement.Domain.Qualifications.Models;

using Destructurama.Attributed;

public sealed record QualificationForCreation
{
    public Guid FacultyID { get; set; }
    public string Degree { get; set; }
    public string Institution { get; set; }
    public int YearOfCompletion { get; set; }
}
