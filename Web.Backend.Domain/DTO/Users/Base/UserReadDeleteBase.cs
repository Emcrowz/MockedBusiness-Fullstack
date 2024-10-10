using Web.Backend.Domain.DTO.Education;

namespace Web.Backend.Domain.DTO.Users.Base;

public abstract record UserReadDeleteBase
{
    public string? Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public int Age { get; init; }
    public List<CourseReadDto>? Courses { get; init; }
}
