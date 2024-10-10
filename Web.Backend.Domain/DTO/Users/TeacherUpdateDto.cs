using System.ComponentModel.DataAnnotations;
using Web.Backend.Domain.DTO.Users.Base;

namespace Web.Backend.Domain.DTO.Users;

public record TeacherUpdateDto : UserReadDeleteBase
{
    [Required]
    public string Id { get; init; }
    [Required, StringLength(50), MinLength(2)]
    public string FirstName { get; init; }
    [Required, StringLength(50), MinLength(2)]
    public string LastName { get; init; }
    [Required, Range(12, 60)]
    public int Age { get; init; }
    public List<StudentReadDto>? Students { get; init; }
}
