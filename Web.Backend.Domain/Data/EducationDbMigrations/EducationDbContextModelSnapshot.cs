﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.Backend.Domain.Data;

#nullable disable

namespace Web.Backend.Domain.Data.EducationDbMigrations
{
    [DbContext(typeof(EducationDbContext))]
    partial class EducationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Web.Backend.Domain.Models.Course", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("ChapterId")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Commitment")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("CourseCreatedById")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("CourseSessionId")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("MinGrade")
                        .HasColumnType("DECIMAL(5, 2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("OnCourseId")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(8, 2)");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("SpecializationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("UpdateDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.HasIndex("CourseCreatedById");

                    b.HasIndex("CourseSessionId");

                    b.HasIndex("OnCourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.CourseDetails.Chapter", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaterialId")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.CourseDetails.CourseCreatedBy", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstitutionId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CourseCreatedBy");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.CourseDetails.Material", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("ChapterId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMandatory")
                        .HasColumnType("bit");

                    b.Property<string>("MaterialLink")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MaterialNumber")
                        .HasColumnType("int");

                    b.Property<string>("MaterialTypeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxPoints")
                        .HasColumnType("int");

                    b.Property<string>("StudentResultsId")
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.HasIndex("StudentResultsId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.CourseDetails.MaterialType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("MaterialId")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.ToTable("MaterialTypes");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.CourseDetails.OnCourse", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LecturerId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OnCourses");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.Institution", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("CourseCreatedById")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("LecturerId")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("SpecializationCreatedById")
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.HasIndex("CourseCreatedById");

                    b.HasIndex("LecturerId");

                    b.HasIndex("SpecializationCreatedById");

                    b.ToTable("Institutions");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.Lecturer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("InstitutionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("OnCourseId")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("OnSpecializationId")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Title")
                        .HasColumnType("VARCHAR(32)");

                    b.HasKey("Id");

                    b.HasIndex("OnCourseId");

                    b.HasIndex("OnSpecializationId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.SpecializationDetails.OnSpecialization", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("LecturerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecializationId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OnSpecializations");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.SpecializationDetails.Specialization", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("CourseId")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("OnSpecializationId")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("SpecializationCreatedById")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<decimal>("SpecializationDiscount")
                        .HasColumnType("DECIMAL(8, 2)");

                    b.Property<string>("SpecializationSessionId")
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("OnSpecializationId");

                    b.HasIndex("SpecializationCreatedById");

                    b.HasIndex("SpecializationSessionId");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.SpecializationDetails.SpecializationCreatedBy", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("InstitutionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecializationId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SpecializationCreatedBy");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.Student", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("EnrolledCourseId")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("EnrolledSpecializationId")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EnrolledCourseId");

                    b.HasIndex("EnrolledSpecializationId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.StudentParticipation.CourseSession", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("DATE");

                    b.Property<string>("EnrolledCourseId")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("SpecializationSessionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("DATE");

                    b.HasKey("Id");

                    b.HasIndex("EnrolledCourseId");

                    b.ToTable("CourseSessions");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.StudentParticipation.EnrolledCourse", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("CertificateId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CertificateLocation")
                        .HasColumnType("TEXT");

                    b.Property<string>("CourseSessionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("DATE");

                    b.Property<decimal?>("FinalGrade")
                        .HasColumnType("DECIMAL(5, 2)");

                    b.Property<DateOnly?>("StatusDate")
                        .HasColumnType("DATE");

                    b.Property<string>("StatusId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentResultsId")
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.HasIndex("StudentResultsId");

                    b.ToTable("EnrolledCourses");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.StudentParticipation.EnrolledSpecialization", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("CertificateId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CertificateLocation")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("EnrollmentDate")
                        .HasColumnType("DATE");

                    b.Property<decimal?>("FinalGrade")
                        .HasColumnType("DECIMAL(5, 2)");

                    b.Property<string>("SpecializationSessionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("StatusDate")
                        .HasColumnType("DATE");

                    b.Property<string>("StatusId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EnrolledSpecializations");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.StudentParticipation.SpecializationSession", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("CourseSessionId")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("DATE");

                    b.Property<string>("EnrolledSpecializationId")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("SpecializationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("DATE");

                    b.HasKey("Id");

                    b.HasIndex("CourseSessionId");

                    b.HasIndex("EnrolledSpecializationId");

                    b.ToTable("SpecializationSessions");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.StudentParticipation.Status", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("EnrolledCourseId")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("EnrolledSpecializationId")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.HasIndex("EnrolledCourseId");

                    b.HasIndex("EnrolledSpecializationId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.StudentParticipation.StudentResults", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<int>("Attempt")
                        .HasColumnType("int");

                    b.Property<string>("AttemptLink")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Ended")
                        .HasColumnType("DATETIME");

                    b.Property<string>("EnrolledCourseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaterialId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<byte[]>("Started")
                        .IsRequired()
                        .HasColumnType("TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("StudentResults");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.Course", b =>
                {
                    b.HasOne("Web.Backend.Domain.Models.CourseDetails.Chapter", null)
                        .WithMany("Courses")
                        .HasForeignKey("ChapterId");

                    b.HasOne("Web.Backend.Domain.Models.CourseDetails.CourseCreatedBy", null)
                        .WithMany("Courses")
                        .HasForeignKey("CourseCreatedById");

                    b.HasOne("Web.Backend.Domain.Models.StudentParticipation.CourseSession", null)
                        .WithMany("Courses")
                        .HasForeignKey("CourseSessionId");

                    b.HasOne("Web.Backend.Domain.Models.CourseDetails.OnCourse", null)
                        .WithMany("Courses")
                        .HasForeignKey("OnCourseId");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.CourseDetails.Chapter", b =>
                {
                    b.HasOne("Web.Backend.Domain.Models.CourseDetails.Material", null)
                        .WithMany("Chapters")
                        .HasForeignKey("MaterialId");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.CourseDetails.Material", b =>
                {
                    b.HasOne("Web.Backend.Domain.Models.StudentParticipation.StudentResults", null)
                        .WithMany("Materials")
                        .HasForeignKey("StudentResultsId");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.CourseDetails.MaterialType", b =>
                {
                    b.HasOne("Web.Backend.Domain.Models.CourseDetails.Material", null)
                        .WithMany("MaterialTypes")
                        .HasForeignKey("MaterialId");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.Institution", b =>
                {
                    b.HasOne("Web.Backend.Domain.Models.CourseDetails.CourseCreatedBy", null)
                        .WithMany("Institutions")
                        .HasForeignKey("CourseCreatedById");

                    b.HasOne("Web.Backend.Domain.Models.Lecturer", null)
                        .WithMany("Institutions")
                        .HasForeignKey("LecturerId");

                    b.HasOne("Web.Backend.Domain.Models.SpecializationDetails.SpecializationCreatedBy", null)
                        .WithMany("Institutions")
                        .HasForeignKey("SpecializationCreatedById");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.Lecturer", b =>
                {
                    b.HasOne("Web.Backend.Domain.Models.CourseDetails.OnCourse", null)
                        .WithMany("Lecturers")
                        .HasForeignKey("OnCourseId");

                    b.HasOne("Web.Backend.Domain.Models.SpecializationDetails.OnSpecialization", null)
                        .WithMany("Lecturers")
                        .HasForeignKey("OnSpecializationId");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.SpecializationDetails.Specialization", b =>
                {
                    b.HasOne("Web.Backend.Domain.Models.Course", null)
                        .WithMany("Specializations")
                        .HasForeignKey("CourseId");

                    b.HasOne("Web.Backend.Domain.Models.SpecializationDetails.OnSpecialization", null)
                        .WithMany("Specializations")
                        .HasForeignKey("OnSpecializationId");

                    b.HasOne("Web.Backend.Domain.Models.SpecializationDetails.SpecializationCreatedBy", null)
                        .WithMany("Specializations")
                        .HasForeignKey("SpecializationCreatedById");

                    b.HasOne("Web.Backend.Domain.Models.StudentParticipation.SpecializationSession", null)
                        .WithMany("Specializations")
                        .HasForeignKey("SpecializationSessionId");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.Student", b =>
                {
                    b.HasOne("Web.Backend.Domain.Models.StudentParticipation.EnrolledCourse", null)
                        .WithMany("Students")
                        .HasForeignKey("EnrolledCourseId");

                    b.HasOne("Web.Backend.Domain.Models.StudentParticipation.EnrolledSpecialization", null)
                        .WithMany("Students")
                        .HasForeignKey("EnrolledSpecializationId");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.StudentParticipation.CourseSession", b =>
                {
                    b.HasOne("Web.Backend.Domain.Models.StudentParticipation.EnrolledCourse", null)
                        .WithMany("CourseSessions")
                        .HasForeignKey("EnrolledCourseId");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.StudentParticipation.EnrolledCourse", b =>
                {
                    b.HasOne("Web.Backend.Domain.Models.StudentParticipation.StudentResults", null)
                        .WithMany("EnrolledCourses")
                        .HasForeignKey("StudentResultsId");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.StudentParticipation.SpecializationSession", b =>
                {
                    b.HasOne("Web.Backend.Domain.Models.StudentParticipation.CourseSession", null)
                        .WithMany("SpecializationSessions")
                        .HasForeignKey("CourseSessionId");

                    b.HasOne("Web.Backend.Domain.Models.StudentParticipation.EnrolledSpecialization", null)
                        .WithMany("SpecializationSessions")
                        .HasForeignKey("EnrolledSpecializationId");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.StudentParticipation.Status", b =>
                {
                    b.HasOne("Web.Backend.Domain.Models.StudentParticipation.EnrolledCourse", null)
                        .WithMany("Status")
                        .HasForeignKey("EnrolledCourseId");

                    b.HasOne("Web.Backend.Domain.Models.StudentParticipation.EnrolledSpecialization", null)
                        .WithMany("Status")
                        .HasForeignKey("EnrolledSpecializationId");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.Course", b =>
                {
                    b.Navigation("Specializations");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.CourseDetails.Chapter", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.CourseDetails.CourseCreatedBy", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Institutions");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.CourseDetails.Material", b =>
                {
                    b.Navigation("Chapters");

                    b.Navigation("MaterialTypes");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.CourseDetails.OnCourse", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Lecturers");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.Lecturer", b =>
                {
                    b.Navigation("Institutions");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.SpecializationDetails.OnSpecialization", b =>
                {
                    b.Navigation("Lecturers");

                    b.Navigation("Specializations");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.SpecializationDetails.SpecializationCreatedBy", b =>
                {
                    b.Navigation("Institutions");

                    b.Navigation("Specializations");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.StudentParticipation.CourseSession", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("SpecializationSessions");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.StudentParticipation.EnrolledCourse", b =>
                {
                    b.Navigation("CourseSessions");

                    b.Navigation("Status");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.StudentParticipation.EnrolledSpecialization", b =>
                {
                    b.Navigation("SpecializationSessions");

                    b.Navigation("Status");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.StudentParticipation.SpecializationSession", b =>
                {
                    b.Navigation("Specializations");
                });

            modelBuilder.Entity("Web.Backend.Domain.Models.StudentParticipation.StudentResults", b =>
                {
                    b.Navigation("EnrolledCourses");

                    b.Navigation("Materials");
                });
#pragma warning restore 612, 618
        }
    }
}
