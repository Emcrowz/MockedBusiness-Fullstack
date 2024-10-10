using Web.Backend.Domain.Models.Users;

namespace Web.Backend.Domain.Models.Education;

public class Assignment
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public string? StudentId { get; set; }
    public Student? Student { get; set; }
}
