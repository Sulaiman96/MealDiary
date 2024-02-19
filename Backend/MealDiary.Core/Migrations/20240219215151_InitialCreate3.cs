using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealDiary.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealCollections_AspNetUsers_AppUserId",
                table: "MealCollections");

            migrationBuilder.AddForeignKey(
                name: "FK_MealCollections_AspNetUsers_AppUserId",
                table: "MealCollections",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealCollections_AspNetUsers_AppUserId",
                table: "MealCollections");

            migrationBuilder.AddForeignKey(
                name: "FK_MealCollections_AspNetUsers_AppUserId",
                table: "MealCollections",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
