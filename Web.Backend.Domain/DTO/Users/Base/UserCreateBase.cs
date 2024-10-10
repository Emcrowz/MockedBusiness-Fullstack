using System.ComponentModel.DataAnnotations;

namespace Web.Backend.Domain.DTO.Users.Base;

public abstract record UserCreateBase
{
    [Required, StringLength(50), MinLength(2)]
    public string? FirstName { get; init; }
    [Required, StringLength(50), MinLength(2)]
    public string? LastName { get; init; }
    [Required, Range(12, 60)]
    public int Age { get; init; }
}
