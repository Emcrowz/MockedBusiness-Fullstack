using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models;

public class Student
{
    [Key, Column(TypeName = "VARCHAR(255)")] public string Id { get; set; }
    [Column(TypeName = "VARCHAR(64)")] public string FirstName { get; set; }
    [Column(TypeName = "VARCHAR(64)")] public string LastName { get; set; }
    [Column(TypeName = "TEXT")] public string? Location { get; set; }
}
