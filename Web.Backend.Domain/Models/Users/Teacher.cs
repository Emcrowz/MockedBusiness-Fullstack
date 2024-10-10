using Web.Backend.Domain.Models.Users.Base;

namespace Web.Backend.Domain.Models.Users;

public class Teacher : User
{
    public string? StudentId { get; set; }
    public List<Student>? Students { get; set; }
}
