using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DbStudentHelper.Migrations
{
    /// <inheritdoc />
    public partial class Add_All_Basic_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUser_Roles_RoleId",
                table: "tblUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "tblRole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblRole",
                table: "tblRole",
                column: "RoleId");

            migrationBuilder.CreateTable(
                name: "tblLocation",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Physical = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLocation", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "tblEducationInstitution",
                columns: table => new
                {
                    EducationInstitutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEducationInstitution", x => x.EducationInstitutionId);
                    table.ForeignKey(
                        name: "FK_tblEducationInstitution_tblLocation_LocationId",
                        column: x => x.LocationId,
                        principalTable: "tblLocation",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblClass",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    EducationInstitutionId = table.Column<int>(type: "int", nullable: false),
                    HeadTeacherId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClass", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_tblClass_tblEducationInstitution_EducationInstitutionId",
                        column: x => x.EducationInstitutionId,
                        principalTable: "tblEducationInstitution",
                        principalColumn: "EducationInstitutionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblClass_tblUser_HeadTeacherId",
                        column: x => x.HeadTeacherId,
                        principalTable: "tblUser",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "tblSubject",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSubject", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_tblSubject_tblClass_ClassId",
                        column: x => x.ClassId,
                        principalTable: "tblClass",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSubject_tblUser_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "tblUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ztblClassStudent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ztblClassStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ztblClassStudent_tblClass_ClassId",
                        column: x => x.ClassId,
                        principalTable: "tblClass",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ztblClassStudent_tblUser_StudentId",
                        column: x => x.StudentId,
                        principalTable: "tblUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMark",
                columns: table => new
                {
                    MarkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMark", x => x.MarkId);
                    table.ForeignKey(
                        name: "FK_tblMark_tblSubject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "tblSubject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblMark_tblUser_StudentId",
                        column: x => x.StudentId,
                        principalTable: "tblUser",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "tblTask",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTask", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_tblTask_tblSubject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "tblSubject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ztblTaskPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    MarkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ztblTaskPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ztblTaskPerson_tblMark_MarkId",
                        column: x => x.MarkId,
                        principalTable: "tblMark",
                        principalColumn: "MarkId");
                    table.ForeignKey(
                        name: "FK_ztblTaskPerson_tblTask_TaskId",
                        column: x => x.TaskId,
                        principalTable: "tblTask",
                        principalColumn: "TaskId");
                    table.ForeignKey(
                        name: "FK_ztblTaskPerson_tblUser_StudentId",
                        column: x => x.StudentId,
                        principalTable: "tblUser",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "tblRole",
                columns: new[] { "RoleId", "Role" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Student" },
                    { 3, "Teacher" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblClass_EducationInstitutionId",
                table: "tblClass",
                column: "EducationInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblClass_HeadTeacherId",
                table: "tblClass",
                column: "HeadTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEducationInstitution_LocationId",
                table: "tblEducationInstitution",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMark_StudentId",
                table: "tblMark",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMark_SubjectId",
                table: "tblMark",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSubject_ClassId",
                table: "tblSubject",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSubject_TeacherId",
                table: "tblSubject",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTask_SubjectId",
                table: "tblTask",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ztblClassStudent_ClassId",
                table: "ztblClassStudent",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ztblClassStudent_StudentId",
                table: "ztblClassStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ztblTaskPerson_MarkId",
                table: "ztblTaskPerson",
                column: "MarkId");

            migrationBuilder.CreateIndex(
                name: "IX_ztblTaskPerson_StudentId",
                table: "ztblTaskPerson",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ztblTaskPerson_TaskId",
                table: "ztblTaskPerson",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUser_tblRole_RoleId",
                table: "tblUser",
                column: "RoleId",
                principalTable: "tblRole",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUser_tblRole_RoleId",
                table: "tblUser");

            migrationBuilder.DropTable(
                name: "ztblClassStudent");

            migrationBuilder.DropTable(
                name: "ztblTaskPerson");

            migrationBuilder.DropTable(
                name: "tblMark");

            migrationBuilder.DropTable(
                name: "tblTask");

            migrationBuilder.DropTable(
                name: "tblSubject");

            migrationBuilder.DropTable(
                name: "tblClass");

            migrationBuilder.DropTable(
                name: "tblEducationInstitution");

            migrationBuilder.DropTable(
                name: "tblLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblRole",
                table: "tblRole");

            migrationBuilder.DeleteData(
                table: "tblRole",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblRole",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblRole",
                keyColumn: "RoleId",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "tblRole",
                newName: "Roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUser_Roles_RoleId",
                table: "tblUser",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
