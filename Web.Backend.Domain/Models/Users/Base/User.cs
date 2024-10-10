using Web.Backend.Domain.Models.Education;

namespace Web.Backend.Domain.Models.Users.Base;

public abstract class User
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public string? CourseId { get; set; }
    public List<Course>? Courses { get; set; }
}
