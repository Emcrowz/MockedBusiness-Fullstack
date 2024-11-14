using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Backend.Domain.Data.EducationDbMigrations
{
    /// <inheritdoc />
    public partial class InitialProjectMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseCreatedBy",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    InstitutionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCreatedBy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnrolledSpecializations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecializationSessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrollmentDate = table.Column<DateOnly>(type: "DATE", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusDate = table.Column<DateOnly>(type: "DATE", nullable: true),
                    FinalGrade = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: true),
                    CertificateId = table.Column<string>(type: "TEXT", nullable: true),
                    CertificateLocation = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolledSpecializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnCourses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    LecturerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnCourses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnSpecializations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    LecturerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecializationId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnSpecializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecializationCreatedBy",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    InstitutionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecializationId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializationCreatedBy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentResults",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    MaterialId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrolledCourseId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attempt = table.Column<int>(type: "int", nullable: false),
                    AttemptLink = table.Column<string>(type: "TEXT", nullable: true),
                    Started = table.Column<byte[]>(type: "TIMESTAMP", nullable: false),
                    Ended = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    FirstName = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(32)", nullable: true),
                    InstitutionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnCourseId = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    OnSpecializationId = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_OnCourses_OnCourseId",
                        column: x => x.OnCourseId,
                        principalTable: "OnCourses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teachers_OnSpecializations_OnSpecializationId",
                        column: x => x.OnSpecializationId,
                        principalTable: "OnSpecializations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EnrolledCourses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseSessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusDate = table.Column<DateOnly>(type: "DATE", nullable: true),
                    FinalGrade = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: true),
                    CertificateId = table.Column<string>(type: "TEXT", nullable: true),
                    CertificateLocation = table.Column<string>(type: "TEXT", nullable: true),
                    StudentResultsId = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolledCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrolledCourses_StudentResults_StudentResultsId",
                        column: x => x.StudentResultsId,
                        principalTable: "StudentResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    ChapterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialNumber = table.Column<int>(type: "int", nullable: false),
                    MaterialTypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialLink = table.Column<string>(type: "TEXT", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    MaxPoints = table.Column<int>(type: "int", nullable: false),
                    StudentResultsId = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_StudentResults_StudentResultsId",
                        column: x => x.StudentResultsId,
                        principalTable: "StudentResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Location = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    CourseCreatedById = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    LecturerId = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    SpecializationCreatedById = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Institutions_CourseCreatedBy_CourseCreatedById",
                        column: x => x.CourseCreatedById,
                        principalTable: "CourseCreatedBy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Institutions_SpecializationCreatedBy_SpecializationCreatedById",
                        column: x => x.SpecializationCreatedById,
                        principalTable: "SpecializationCreatedBy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Institutions_Teachers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseSessions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "DATE", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "DATE", nullable: false),
                    SpecializationSessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrolledCourseId = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSessions_EnrolledCourses_EnrolledCourseId",
                        column: x => x.EnrolledCourseId,
                        principalTable: "EnrolledCourses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    StatusName = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    EnrolledCourseId = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    EnrolledSpecializationId = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Status_EnrolledCourses_EnrolledCourseId",
                        column: x => x.EnrolledCourseId,
                        principalTable: "EnrolledCourses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Status_EnrolledSpecializations_EnrolledSpecializationId",
                        column: x => x.EnrolledSpecializationId,
                        principalTable: "EnrolledSpecializations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    FirstName = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    EnrolledCourseId = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    EnrolledSpecializationId = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_EnrolledCourses_EnrolledCourseId",
                        column: x => x.EnrolledCourseId,
                        principalTable: "EnrolledCourses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_EnrolledSpecializations_EnrolledSpecializationId",
                        column: x => x.EnrolledSpecializationId,
                        principalTable: "EnrolledSpecializations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    MaterialId = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MaterialTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    TypeName = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    MaterialId = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialTypes_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SpecializationSessions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    SpecializationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "DATE", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "DATE", nullable: false),
                    CourseSessionId = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    EnrolledSpecializationId = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializationSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecializationSessions_CourseSessions_CourseSessionId",
                        column: x => x.CourseSessionId,
                        principalTable: "CourseSessions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecializationSessions_EnrolledSpecializations_EnrolledSpecializationId",
                        column: x => x.EnrolledSpecializationId,
                        principalTable: "EnrolledSpecializations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Commitment = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    MinGrade = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SpecializationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdateDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ChapterId = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    CourseCreatedById = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    CourseSessionId = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    OnCourseId = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_CourseCreatedBy_CourseCreatedById",
                        column: x => x.CourseCreatedById,
                        principalTable: "CourseCreatedBy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_CourseSessions_CourseSessionId",
                        column: x => x.CourseSessionId,
                        principalTable: "CourseSessions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_OnCourses_OnCourseId",
                        column: x => x.OnCourseId,
                        principalTable: "OnCourses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    SpecializationDiscount = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CourseId = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    OnSpecializationId = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    SpecializationCreatedById = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    SpecializationSessionId = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specializations_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specializations_OnSpecializations_OnSpecializationId",
                        column: x => x.OnSpecializationId,
                        principalTable: "OnSpecializations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specializations_SpecializationCreatedBy_SpecializationCreatedById",
                        column: x => x.SpecializationCreatedById,
                        principalTable: "SpecializationCreatedBy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specializations_SpecializationSessions_SpecializationSessionId",
                        column: x => x.SpecializationSessionId,
                        principalTable: "SpecializationSessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_MaterialId",
                table: "Chapters",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ChapterId",
                table: "Courses",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseCreatedById",
                table: "Courses",
                column: "CourseCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseSessionId",
                table: "Courses",
                column: "CourseSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_OnCourseId",
                table: "Courses",
                column: "OnCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSessions_EnrolledCourseId",
                table: "CourseSessions",
                column: "EnrolledCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledCourses_StudentResultsId",
                table: "EnrolledCourses",
                column: "StudentResultsId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_CourseCreatedById",
                table: "Institutions",
                column: "CourseCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_LecturerId",
                table: "Institutions",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_SpecializationCreatedById",
                table: "Institutions",
                column: "SpecializationCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_StudentResultsId",
                table: "Materials",
                column: "StudentResultsId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTypes_MaterialId",
                table: "MaterialTypes",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_CourseId",
                table: "Specializations",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_OnSpecializationId",
                table: "Specializations",
                column: "OnSpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_SpecializationCreatedById",
                table: "Specializations",
                column: "SpecializationCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_SpecializationSessionId",
                table: "Specializations",
                column: "SpecializationSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationSessions_CourseSessionId",
                table: "SpecializationSessions",
                column: "CourseSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationSessions_EnrolledSpecializationId",
                table: "SpecializationSessions",
                column: "EnrolledSpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_EnrolledCourseId",
                table: "Status",
                column: "EnrolledCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_EnrolledSpecializationId",
                table: "Status",
                column: "EnrolledSpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_EnrolledCourseId",
                table: "Students",
                column: "EnrolledCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_EnrolledSpecializationId",
                table: "Students",
                column: "EnrolledSpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_OnCourseId",
                table: "Teachers",
                column: "OnCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_OnSpecializationId",
                table: "Teachers",
                column: "OnSpecializationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "MaterialTypes");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "SpecializationCreatedBy");

            migrationBuilder.DropTable(
                name: "SpecializationSessions");

            migrationBuilder.DropTable(
                name: "OnSpecializations");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "CourseCreatedBy");

            migrationBuilder.DropTable(
                name: "OnCourses");

            migrationBuilder.DropTable(
                name: "CourseSessions");

            migrationBuilder.DropTable(
                name: "EnrolledSpecializations");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "EnrolledCourses");

            migrationBuilder.DropTable(
                name: "StudentResults");
        }
    }
}
