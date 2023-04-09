using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    /// <inheritdoc />
    public partial class detailTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "detailTours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_diadiem = table.Column<int>(type: "int", nullable: false),
                    id_tour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailTours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detailTours_DIADIEMs_id_diadiem",
                        column: x => x.id_diadiem,
                        principalTable: "DIADIEMs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detailTours_tours_id_tour",
                        column: x => x.id_tour,
                        principalTable: "tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detailTours_id_diadiem",
                table: "detailTours",
                column: "id_diadiem");

            migrationBuilder.CreateIndex(
                name: "IX_detailTours_id_tour",
                table: "detailTours",
                column: "id_tour");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detailTours");
        }
    }
}
