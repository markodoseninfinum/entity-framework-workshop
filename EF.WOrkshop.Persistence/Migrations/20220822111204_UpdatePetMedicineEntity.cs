using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF.Workshop.Persistence.Migrations
{
    public partial class UpdatePetMedicineEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePet_Medicine_MedicinesId",
                table: "MedicinePet");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePet_Pets_PetsId",
                table: "MedicinePet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicine",
                table: "Medicine");

            migrationBuilder.RenameTable(
                name: "Medicine",
                newName: "Medicines");

            migrationBuilder.RenameColumn(
                name: "PetsId",
                table: "MedicinePet",
                newName: "PetId");

            migrationBuilder.RenameColumn(
                name: "MedicinesId",
                table: "MedicinePet",
                newName: "MedicineId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicinePet_PetsId",
                table: "MedicinePet",
                newName: "IX_MedicinePet_PetId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "MedicinePet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MedicineId1",
                table: "MedicinePet",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PetId1",
                table: "MedicinePet",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "MedicinePet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Medicines",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicines",
                table: "Medicines",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePet_MedicineId1",
                table: "MedicinePet",
                column: "MedicineId1");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePet_PetId1",
                table: "MedicinePet",
                column: "PetId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinePet_Medicines_MedicineId",
                table: "MedicinePet",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinePet_Medicines_MedicineId1",
                table: "MedicinePet",
                column: "MedicineId1",
                principalTable: "Medicines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinePet_Pets_PetId",
                table: "MedicinePet",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinePet_Pets_PetId1",
                table: "MedicinePet",
                column: "PetId1",
                principalTable: "Pets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePet_Medicines_MedicineId",
                table: "MedicinePet");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePet_Medicines_MedicineId1",
                table: "MedicinePet");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePet_Pets_PetId",
                table: "MedicinePet");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePet_Pets_PetId1",
                table: "MedicinePet");

            migrationBuilder.DropIndex(
                name: "IX_MedicinePet_MedicineId1",
                table: "MedicinePet");

            migrationBuilder.DropIndex(
                name: "IX_MedicinePet_PetId1",
                table: "MedicinePet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicines",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "MedicinePet");

            migrationBuilder.DropColumn(
                name: "MedicineId1",
                table: "MedicinePet");

            migrationBuilder.DropColumn(
                name: "PetId1",
                table: "MedicinePet");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "MedicinePet");

            migrationBuilder.RenameTable(
                name: "Medicines",
                newName: "Medicine");

            migrationBuilder.RenameColumn(
                name: "PetId",
                table: "MedicinePet",
                newName: "PetsId");

            migrationBuilder.RenameColumn(
                name: "MedicineId",
                table: "MedicinePet",
                newName: "MedicinesId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicinePet_PetId",
                table: "MedicinePet",
                newName: "IX_MedicinePet_PetsId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Medicine",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicine",
                table: "Medicine",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinePet_Medicine_MedicinesId",
                table: "MedicinePet",
                column: "MedicinesId",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinePet_Pets_PetsId",
                table: "MedicinePet",
                column: "PetsId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
