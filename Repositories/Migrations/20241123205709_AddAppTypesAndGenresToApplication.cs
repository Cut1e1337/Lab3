using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddAppTypesAndGenresToApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationID",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationID",
                table: "AppTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_ApplicationID",
                table: "Genres",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_AppTypes_ApplicationID",
                table: "AppTypes",
                column: "ApplicationID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTypes_Applications_ApplicationID",
                table: "AppTypes",
                column: "ApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Applications_ApplicationID",
                table: "Genres",
                column: "ApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTypes_Applications_ApplicationID",
                table: "AppTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Applications_ApplicationID",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_ApplicationID",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_AppTypes_ApplicationID",
                table: "AppTypes");

            migrationBuilder.DropColumn(
                name: "ApplicationID",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ApplicationID",
                table: "AppTypes");
        }
    }
}
