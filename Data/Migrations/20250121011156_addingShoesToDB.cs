using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication10Jan20Country.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingShoesToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shoe",
                columns: table => new
                {
                    ShoeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShoeColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShoeOrginCountry = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoe", x => x.ShoeID);
                    table.ForeignKey(
                        name: "FK_Shoe_Countries_ShoeOrginCountry",
                        column: x => x.ShoeOrginCountry,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_ShoeOrginCountry",
                table: "Shoe",
                column: "ShoeOrginCountry");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shoe");
        }
    }
}
