using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    /// <inheritdoc />
    public partial class bookingDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_tour",
                table: "bookind_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_bookind_Details_id_tour",
                table: "bookind_Details",
                column: "id_tour");

            migrationBuilder.AddForeignKey(
                name: "FK_bookind_Details_tours_id_tour",
                table: "bookind_Details",
                column: "id_tour",
                principalTable: "tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookind_Details_tours_id_tour",
                table: "bookind_Details");

            migrationBuilder.DropIndex(
                name: "IX_bookind_Details_id_tour",
                table: "bookind_Details");

            migrationBuilder.DropColumn(
                name: "id_tour",
                table: "bookind_Details");
        }
    }
}
