using Web.Backend.Domain.DTO.Education;
using Web.Backend.Domain.DTO.Users.Base;

namespace Web.Backend.Domain.DTO.Users;

public record StudentReadDto : UserReadDeleteBase
{
    public List<AssignmentReadDto>? Assignments { get; init; }
}
