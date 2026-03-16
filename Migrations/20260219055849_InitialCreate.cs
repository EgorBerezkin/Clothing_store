using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    Naimenovanie = table.Column<string>(type: "string", nullable: false),
                    Category = table.Column<string>(type: "string", nullable: false),
                    Size = table.Column<string>(type: "string", nullable: false),
                    Color = table.Column<string>(type: "string", nullable: false),
                    Material = table.Column<string>(type: "string", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Clothing", x => x.Naimenovanie);
                });

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    FIO = table.Column<string>(type: "string", nullable: false),
                    Telefon = table.Column<string>(type: "string", nullable: false),
                    Email = table.Column<string>(type: "string", nullable: false),
                    Data_BirthDay = table.Column<DataType>(type: "DataType", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("Buyer", x => x.FIO);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clothes");

            migrationBuilder.DropTable(
                name: "Byuers");
        }
    }
}
