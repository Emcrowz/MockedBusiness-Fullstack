using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models.CourseDetails;

public class MaterialType
{
    [Key, Column(TypeName = "VARCHAR(255)")] public string Id { get; set; }
    [Column(TypeName = "VARCHAR(64)")] public string TypeName { get; set; }
}