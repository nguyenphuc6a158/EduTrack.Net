using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduTrack.Migrations
{
    /// <inheritdoc />
    public partial class reDesignQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileUrl",
                table: "Questions",
                newName: "FileUrlAssignment");

            migrationBuilder.AddColumn<string>(
                name: "FileUrlExplain",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileUrlExplain",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "FileUrlAssignment",
                table: "Questions",
                newName: "FileUrl");
        }
    }
}
