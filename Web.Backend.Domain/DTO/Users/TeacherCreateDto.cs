using Web.Backend.Domain.DTO.Users.Base;

namespace Web.Backend.Domain.DTO.Users;

public record TeacherCreateDto : UserCreateBase
{
    public List<StudentReadDto>? Students { get; init; }
}
