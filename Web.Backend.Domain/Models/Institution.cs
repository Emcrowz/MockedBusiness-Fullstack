using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models;

public class Institution
{
    [Key, Column(TypeName = "VARCHAR(255)")] public string Id { get; set; }
    [Column(TypeName = "VARCHAR(255)")] public string Name { get; set; }
    [Column(TypeName = "VARCHAR(255)")] public string Location { get; set; }
}