using Microsoft.EntityFrameworkCore;
using Web.Backend.Domain.Models;
using Web.Backend.Domain.Models.CourseDetails;
using Web.Backend.Domain.Models.SpecializationDetails;
using Web.Backend.Domain.Models.StudentParticipation;

namespace Web.Backend.Domain.Data;

public class EducationDbContext(DbContextOptions<EducationDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; } 
    public DbSet<Lecturer> Teachers { get; set; } 
    public DbSet<Institution> Institutions { get; set; }
    // Specialization details
    public DbSet<OnSpecialization> OnSpecializations { get; set; }
    public DbSet<Specialization> Specializations { get; set; } // Multi-Use
    public DbSet<SpecializationCreatedBy> SpecializationCreatedBy { get; set; }
    // Course details
    public DbSet<OnCourse> OnCourses { get; set; }
    public DbSet<Course> Courses { get; set; } // Multi-Use
    public DbSet<CourseCreatedBy> CourseCreatedBy { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<MaterialType> MaterialTypes { get; set; }
    public DbSet<Material> Materials { get; set; }
    // Student participation
    public DbSet<SpecializationSession> SpecializationSessions { get; set; }
    public DbSet<EnrolledSpecialization> EnrolledSpecializations { get; set; }
    public DbSet<CourseSession> CourseSessions { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<EnrolledCourse> EnrolledCourses { get; set; }
    public DbSet<StudentResults> StudentResults { get; set; }
}
