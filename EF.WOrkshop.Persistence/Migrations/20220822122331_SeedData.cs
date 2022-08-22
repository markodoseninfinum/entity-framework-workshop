using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF.Workshop.Persistence.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Lijek 1" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Name", "Address_City", "Address_Street" },
                values: new object[] { 1, "Marko Dosen", "Zagreb", "Strojarska Cesta 22" });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "BirthDate", "Gender", "IsFriendly", "Name", "OwnerId" },
                values: new object[] { 1, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), (short)1, true, "Dogo", 1 });

            migrationBuilder.InsertData(
                table: "MedicinePet",
                columns: new[] { "MedicineId", "PetId", "EndDate", "MedicineId1", "PetId1", "StartDate" },
                values: new object[] { 1, 1, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MedicinePet",
                keyColumns: new[] { "MedicineId", "PetId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
