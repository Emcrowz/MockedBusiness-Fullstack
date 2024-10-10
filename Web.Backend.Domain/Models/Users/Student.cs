using Web.Backend.Domain.Models.Education;
using Web.Backend.Domain.Models.Users.Base;

namespace Web.Backend.Domain.Models.Users;

public class Student : User
{
    public string? AssignmentId { get; set; }
    public List<Assignment>? Assignments { get; set; }
}
