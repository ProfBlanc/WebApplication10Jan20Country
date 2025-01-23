using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication10Jan20Country.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingShoeUpload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShoeImage",
                table: "Shoe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "no-image.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShoeImage",
                table: "Shoe");
        }
    }
}
