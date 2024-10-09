using Microsoft.EntityFrameworkCore;
using Web.Backend.Domain.Models.Education;
using Web.Backend.Domain.Models.Users;

namespace Web.Backend.RestAPI.Data;

public class EducationDbContext(DbContextOptions<EducationDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Course> Courses { get; set; }
}
