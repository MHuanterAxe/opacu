using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI01.Infrastructure.Migrations
{
    public partial class ChangeUserForeignKeyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Users_UserForeignKey",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "UserForeignKey",
                table: "Files",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_UserForeignKey",
                table: "Files",
                newName: "IX_Files_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_UserId",
                table: "Files",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Users_UserId",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Files",
                newName: "UserForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Files_UserId",
                table: "Files",
                newName: "IX_Files_UserForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_UserForeignKey",
                table: "Files",
                column: "UserForeignKey",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
