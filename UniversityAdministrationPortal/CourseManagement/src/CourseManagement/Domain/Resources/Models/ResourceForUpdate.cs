namespace CourseManagement.Domain.Resources.Models;

using Destructurama.Attributed;

public sealed record ResourceForUpdate
{
    public string ResourceName { get; set; }
    public string ResourceType { get; set; }
    public int Quantity { get; set; }
    public Guid CourseID { get; set; }
}
