using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduTrack.Migrations
{
    /// <inheritdoc />
    public partial class CreateAssignmentAndClassAssignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AbpUsers_AbpUsesId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_AbpUsers_AbpUsesId",
                table: "StudentClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProgresss_AbpUsers_AbpUsesId",
                table: "StudentProgresss");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProgresss_Chapters_ChapterId",
                table: "StudentProgresss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentProgresss",
                table: "StudentProgresss");

            migrationBuilder.RenameTable(
                name: "StudentProgresss",
                newName: "StudentProgresses");

            migrationBuilder.RenameColumn(
                name: "AbpUsesId",
                table: "StudentClasses",
                newName: "AbpUseId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClasses_AbpUsesId",
                table: "StudentClasses",
                newName: "IX_StudentClasses_AbpUseId");

            migrationBuilder.RenameColumn(
                name: "AbpUsesId",
                table: "Classes",
                newName: "AbpUseId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_AbpUsesId",
                table: "Classes",
                newName: "IX_Classes_AbpUseId");

            migrationBuilder.RenameColumn(
                name: "AbpUsesId",
                table: "StudentProgresses",
                newName: "AbpUseId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentProgresss_ChapterId",
                table: "StudentProgresses",
                newName: "IX_StudentProgresses_ChapterId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentProgresss_AbpUsesId",
                table: "StudentProgresses",
                newName: "IX_StudentProgresses_AbpUseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentProgresses",
                table: "StudentProgresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChapterId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChapterId = table.Column<long>(type: "bigint", nullable: false),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassAssignments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentId = table.Column<long>(type: "bigint", nullable: false),
                    ClassId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassAssignments_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassAssignments_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssignmentQuestions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentId = table.Column<long>(type: "bigint", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    QuestionId1 = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignmentQuestions_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssignmentQuestions_Questions_QuestionId1",
                        column: x => x.QuestionId1,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionOptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionOptions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentQuestions_AssignmentId",
                table: "AssignmentQuestions",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentQuestions_QuestionId",
                table: "AssignmentQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentQuestions_QuestionId1",
                table: "AssignmentQuestions",
                column: "QuestionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ChapterId",
                table: "Assignments",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAssignments_AssignmentId",
                table: "ClassAssignments",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAssignments_ClassId",
                table: "ClassAssignments",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOptions_QuestionId",
                table: "QuestionOptions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ChapterId",
                table: "Questions",
                column: "ChapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AbpUsers_AbpUseId",
                table: "Classes",
                column: "AbpUseId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_AbpUsers_AbpUseId",
                table: "StudentClasses",
                column: "AbpUseId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProgresses_AbpUsers_AbpUseId",
                table: "StudentProgresses",
                column: "AbpUseId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProgresses_Chapters_ChapterId",
                table: "StudentProgresses",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AbpUsers_AbpUseId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_AbpUsers_AbpUseId",
                table: "StudentClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProgresses_AbpUsers_AbpUseId",
                table: "StudentProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProgresses_Chapters_ChapterId",
                table: "StudentProgresses");

            migrationBuilder.DropTable(
                name: "AssignmentQuestions");

            migrationBuilder.DropTable(
                name: "ClassAssignments");

            migrationBuilder.DropTable(
                name: "QuestionOptions");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentProgresses",
                table: "StudentProgresses");

            migrationBuilder.RenameTable(
                name: "StudentProgresses",
                newName: "StudentProgresss");

            migrationBuilder.RenameColumn(
                name: "AbpUseId",
                table: "StudentClasses",
                newName: "AbpUsesId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClasses_AbpUseId",
                table: "StudentClasses",
                newName: "IX_StudentClasses_AbpUsesId");

            migrationBuilder.RenameColumn(
                name: "AbpUseId",
                table: "Classes",
                newName: "AbpUsesId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_AbpUseId",
                table: "Classes",
                newName: "IX_Classes_AbpUsesId");

            migrationBuilder.RenameColumn(
                name: "AbpUseId",
                table: "StudentProgresss",
                newName: "AbpUsesId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentProgresses_ChapterId",
                table: "StudentProgresss",
                newName: "IX_StudentProgresss_ChapterId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentProgresses_AbpUseId",
                table: "StudentProgresss",
                newName: "IX_StudentProgresss_AbpUsesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentProgresss",
                table: "StudentProgresss",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AbpUsers_AbpUsesId",
                table: "Classes",
                column: "AbpUsesId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_AbpUsers_AbpUsesId",
                table: "StudentClasses",
                column: "AbpUsesId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProgresss_AbpUsers_AbpUsesId",
                table: "StudentProgresss",
                column: "AbpUsesId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProgresss_Chapters_ChapterId",
                table: "StudentProgresss",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
