using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models;

public class Lecturer
{
    [Key, Column(TypeName = "VARCHAR(255)")] public string Id { get; set; }
    [Column(TypeName = "VARCHAR(64)")] public string FirstName { get; set; }
    [Column(TypeName = "VARCHAR(64)")] public string LastName { get; set; }
    [Column(TypeName = "VARCHAR(32)")] public string? Title { get; set; }
    [ForeignKey(nameof(Institution))] public string? InstitutionId { get; set; }
    public List<Institution>? Institutions { get; set; }
}
