using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication10Jan20Country.Data.Migrations
{
    /// <inheritdoc />
    public partial class customUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoe_Countries_ShoeOrginCountry",
                table: "Shoe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shoe",
                table: "Shoe");

            migrationBuilder.RenameTable(
                name: "Shoe",
                newName: "Shoes");

            migrationBuilder.RenameIndex(
                name: "IX_Shoe_ShoeOrginCountry",
                table: "Shoes",
                newName: "IX_Shoes_ShoeOrginCountry");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shoes",
                table: "Shoes",
                column: "ShoeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Countries_ShoeOrginCountry",
                table: "Shoes",
                column: "ShoeOrginCountry",
                principalTable: "Countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Countries_ShoeOrginCountry",
                table: "Shoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shoes",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Shoes",
                newName: "Shoe");

            migrationBuilder.RenameIndex(
                name: "IX_Shoes_ShoeOrginCountry",
                table: "Shoe",
                newName: "IX_Shoe_ShoeOrginCountry");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shoe",
                table: "Shoe",
                column: "ShoeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoe_Countries_ShoeOrginCountry",
                table: "Shoe",
                column: "ShoeOrginCountry",
                principalTable: "Countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
