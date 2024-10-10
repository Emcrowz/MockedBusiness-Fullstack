using Web.Backend.Domain.DTO.Education;
using Web.Backend.Domain.DTO.Users.Base;

namespace Web.Backend.Domain.DTO.Users;

public record StudentCreateDto : UserCreateBase
{
    public List<AssignmentReadDto>? Assignments { get; init; }
}
