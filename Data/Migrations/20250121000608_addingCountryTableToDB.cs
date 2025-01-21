using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication10Jan20Country.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingCountryTableToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Continent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapitalCityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
