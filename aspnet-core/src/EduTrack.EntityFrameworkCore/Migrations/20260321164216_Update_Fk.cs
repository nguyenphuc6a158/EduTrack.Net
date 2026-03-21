using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduTrack.Migrations
{
    /// <inheritdoc />
    public partial class Update_Fk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "aId",
                table: "Classes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_aId",
                table: "Classes",
                column: "aId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AbpUsers_aId",
                table: "Classes",
                column: "aId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AbpUsers_aId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_aId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "aId",
                table: "Classes");
        }
    }
}
