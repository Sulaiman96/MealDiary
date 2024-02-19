using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealDiary.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_AspNetUsers_UserId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MealCollections");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Meals",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_UserId",
                table: "Meals",
                newName: "IX_Meals_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_AspNetUsers_AppUserId",
                table: "Meals",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_AspNetUsers_AppUserId",
                table: "Meals");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Meals",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_AppUserId",
                table: "Meals",
                newName: "IX_Meals_UserId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MealCollections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_AspNetUsers_UserId",
                table: "Meals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
