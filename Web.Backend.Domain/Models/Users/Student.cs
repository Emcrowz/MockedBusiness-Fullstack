using Web.Backend.Domain.Models.Education;
using Web.Backend.Domain.Models.Users.Base;

namespace Web.Backend.Domain.Models.Users;

public class Student : User
{
    public string? CourseId { get; set; }
    public List<Course>? Courses { get; set; }
}
