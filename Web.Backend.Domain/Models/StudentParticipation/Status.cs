using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models.StudentParticipation;

public class Status
{
    [Key, Column(TypeName = "VARCHAR(255)")] public string Id { get; set; }
    [Column(TypeName = "VARCHAR(255)")] public string StatusName { get; set; } 
}