using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduTrack.Migrations
{
    /// <inheritdoc />
    public partial class Add_Grade_Class_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AbpUsers_UserId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_UserId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Classes");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_GradeId",
                table: "Classes",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Grades_GradeId",
                table: "Classes",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Grades_GradeId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_GradeId",
                table: "Classes");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Classes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_UserId",
                table: "Classes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AbpUsers_UserId",
                table: "Classes",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }
    }
}
