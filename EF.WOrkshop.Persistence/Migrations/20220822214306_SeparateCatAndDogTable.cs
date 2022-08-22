using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF.Workshop.Persistence.Migrations
{
    public partial class SeparateCatAndDogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "NumberOfGoodBoyPoints",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "NumberOfLifesUsed",
                table: "Pets");

            migrationBuilder.CreateTable(
                name: "Cat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    NumberOfLifesUsed = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_Pets_Id",
                        column: x => x.Id,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    NumberOfGoodBoyPoints = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dog_Pets_Id",
                        column: x => x.Id,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cat",
                columns: new[] { "Id", "NumberOfLifesUsed" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "Dog",
                columns: new[] { "Id", "NumberOfGoodBoyPoints" },
                values: new object[] { 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat");

            migrationBuilder.DropTable(
                name: "Dog");

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfGoodBoyPoints",
                table: "Pets",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLifesUsed",
                table: "Pets",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "BirthDate", "Discriminator", "Gender", "IsFriendly", "Name", "NumberOfLifesUsed", "OwnerId" },
                values: new object[] { 4, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cat", (short)0, true, "Mjau mjau", 1, 1 });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "BirthDate", "Discriminator", "Gender", "IsFriendly", "Name", "NumberOfGoodBoyPoints", "OwnerId" },
                values: new object[] { 3, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Dog", (short)1, true, "Dogo", 3, 1 });
        }
    }
}
