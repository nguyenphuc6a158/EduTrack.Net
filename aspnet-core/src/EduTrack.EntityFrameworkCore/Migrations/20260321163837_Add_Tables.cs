using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduTrack.Migrations
{
    /// <inheritdoc />
    public partial class Add_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_Subjects_SubjectId",
                table: "Chapter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chapter",
                table: "Chapter");

            migrationBuilder.RenameTable(
                name: "Chapter",
                newName: "Chapters");

            migrationBuilder.RenameIndex(
                name: "IX_Chapter_SubjectId",
                table: "Chapters",
                newName: "IX_Chapters_SubjectId");

            migrationBuilder.AlterColumn<long>(
                name: "StudentId",
                table: "StudentClasses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chapters",
                table: "Chapters",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StudentProgresss",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    ChapterId = table.Column<long>(type: "bigint", nullable: false),
                    AvgScore = table.Column<float>(type: "real", nullable: false),
                    TotalAttempts = table.Column<int>(type: "int", nullable: false),
                    TotalCorrect = table.Column<int>(type: "int", nullable: false),
                    TotalQuestions = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProgresss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentProgresss_AbpUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentProgresss_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_ClassId",
                table: "StudentClasses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_StudentId",
                table: "StudentClasses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgresss_ChapterId",
                table: "StudentProgresss",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgresss_StudentId",
                table: "StudentProgresss",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Subjects_SubjectId",
                table: "Chapters",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_AbpUsers_StudentId",
                table: "StudentClasses",
                column: "StudentId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_Classes_ClassId",
                table: "StudentClasses",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Subjects_SubjectId",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_AbpUsers_StudentId",
                table: "StudentClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Classes_ClassId",
                table: "StudentClasses");

            migrationBuilder.DropTable(
                name: "StudentProgresss");

            migrationBuilder.DropIndex(
                name: "IX_StudentClasses_ClassId",
                table: "StudentClasses");

            migrationBuilder.DropIndex(
                name: "IX_StudentClasses_StudentId",
                table: "StudentClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chapters",
                table: "Chapters");

            migrationBuilder.RenameTable(
                name: "Chapters",
                newName: "Chapter");

            migrationBuilder.RenameIndex(
                name: "IX_Chapters_SubjectId",
                table: "Chapter",
                newName: "IX_Chapter_SubjectId");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "StudentClasses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chapter",
                table: "Chapter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_Subjects_SubjectId",
                table: "Chapter",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
