using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Backend.Domain.Models.Materials.Base;

public class Video : StudyMaterial
{
    [Column(TypeName = "NVARCHAR(250)")]
    public string URI { get; set; }
    public TimeOnly Length { get; set; }
}
