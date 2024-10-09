using System.ComponentModel.DataAnnotations.Schema;
using Web.Backend.Domain.Models.Users;

namespace Web.Backend.Domain.Models.Education;

public class Course
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal? Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    public DateTime UpdateDate { get; set; }

    public string? StudentId { get; set; }
    public Student? Student { get; set; }
    public string? TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    //public string? StudyMaterialId { get; set; }
    //public ICollection<StudyMaterial>? StudyMaterials { get; set; }
    public string AssignmentId { get; set; }
    public List<Assignment>? Assignments { get; set; }
}
