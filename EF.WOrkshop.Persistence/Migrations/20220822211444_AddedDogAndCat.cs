using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF.Workshop.Persistence.Migrations
{
    public partial class AddedDogAndCat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "NumberOfGoodBoyPoints",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "NumberOfLifesUsed",
                table: "Pets");

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "BirthDate", "Gender", "IsFriendly", "Name", "OwnerId" },
                values: new object[] { 1, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), (short)1, true, "Dogo", 1 });
        }
    }
}
