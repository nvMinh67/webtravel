using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DIADIEMs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TENDIADIEM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIACHI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MOTA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MAP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIADIEMs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "image_DIADIEM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_DIADIEM = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_image_DIADIEM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_image_DIADIEM_DIADIEMs_id_DIADIEM",
                        column: x => x.id_DIADIEM,
                        principalTable: "DIADIEMs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_image_DIADIEM_id_DIADIEM",
                table: "image_DIADIEM",
                column: "id_DIADIEM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "image_DIADIEM");

            migrationBuilder.DropTable(
                name: "DIADIEMs");
        }
    }
}
