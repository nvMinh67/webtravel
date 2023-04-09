using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    /// <inheritdoc />
    public partial class updatea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tours_id_user",
                table: "tours");

            migrationBuilder.DropColumn(
                name: "id_user",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_tours_id_user",
                table: "tours",
                column: "id_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tours_id_user",
                table: "tours");

            migrationBuilder.AddColumn<int>(
                name: "id_user",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tours_id_user",
                table: "tours",
                column: "id_user",
                unique: true);
        }
    }
}
