using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduTrack.Migrations
{
    /// <inheritdoc />
    public partial class Update_Fkv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AbpUsers_aId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProgresss_AbpUsers_StudentId",
                table: "StudentProgresss");

            migrationBuilder.DropIndex(
                name: "IX_StudentProgresss_StudentId",
                table: "StudentProgresss");

            migrationBuilder.RenameColumn(
                name: "aId",
                table: "Classes",
                newName: "AbpUsesId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_aId",
                table: "Classes",
                newName: "IX_Classes_AbpUsesId");

            migrationBuilder.AddColumn<long>(
                name: "AbpUsesId",
                table: "StudentProgresss",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AbpUsesId",
                table: "StudentClasses",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgresss_AbpUsesId",
                table: "StudentProgresss",
                column: "AbpUsesId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_AbpUsesId",
                table: "StudentClasses",
                column: "AbpUsesId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_StudentProgresss_AbpUsesId",
                table: "StudentProgresss");

            migrationBuilder.DropIndex(
                name: "IX_StudentClasses_AbpUsesId",
                table: "StudentClasses");

            migrationBuilder.DropColumn(
                name: "AbpUsesId",
                table: "StudentProgresss");

            migrationBuilder.DropColumn(
                name: "AbpUsesId",
                table: "StudentClasses");

            migrationBuilder.RenameColumn(
                name: "AbpUsesId",
                table: "Classes",
                newName: "aId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_AbpUsesId",
                table: "Classes",
                newName: "IX_Classes_aId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgresss_StudentId",
                table: "StudentProgresss",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AbpUsers_aId",
                table: "Classes",
                column: "aId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProgresss_AbpUsers_StudentId",
                table: "StudentProgresss",
                column: "StudentId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
