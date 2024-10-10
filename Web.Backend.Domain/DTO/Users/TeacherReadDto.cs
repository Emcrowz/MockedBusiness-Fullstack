using Web.Backend.Domain.DTO.Users.Base;

namespace Web.Backend.Domain.DTO.Users;

public record TeacherReadDto : UserReadDeleteBase
{
    public List<StudentReadDto>? Students { get; init; }
}
