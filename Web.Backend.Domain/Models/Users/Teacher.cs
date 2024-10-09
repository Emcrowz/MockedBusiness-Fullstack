using Web.Backend.Domain.Models.Education;
using Web.Backend.Domain.Models.Users.Base;

namespace Web.Backend.Domain.Models.Users;

public class Teacher : User
{
    public string? CourseId { get; set; }
    public List<Course>? Courses { get; set; }
    public string? StudentId { get; set; }
    public List<Student>? Students { get; set; }
}
