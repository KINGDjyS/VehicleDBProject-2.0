using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleService.Migrations
{
    public partial class PopulateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VehicleMakers",
                columns: new[] { "VehicleMakeId", "Abrv", "Name" },
                values: new object[,]
                {
                    { 1, "BMW", "Bmw" },
                    { 2, "JAG", "Jaguar" },
                    { 3, "FRD", "Ford" },
                    { 4, "NIS", "Nissan" },
                    { 5, "VW", "VolksWagen" }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "VehicleModelId", "Abrv", "Name", "VehicleMakeId" },
                values: new object[,]
                {
                    { 2, "340", "340 Gran Turismo", 1 },
                    { 7, "550", "M550", 1 },
                    { 15, "228", "228 Gran Coupe", 1 },
                    { 4, "XE", "XE", 2 },
                    { 10, "IPC", "I-Pace", 2 },
                    { 12, "FTP", "F-Type Coupe", 2 },
                    { 3, "F15", "F-150", 3 },
                    { 6, "FCS", "Focus", 3 },
                    { 13, "MST", "Mustang", 3 },
                    { 5, "GTR", "GT-R", 4 },
                    { 9, "350", "350Z", 4 },
                    { 11, "FRN", "Frontier", 4 },
                    { 1, "TO2", "Touareg2", 5 },
                    { 8, "GLI", "Jetta GLI", 5 },
                    { 14, "ART", "Arteon", 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "VehicleMakers",
                keyColumn: "VehicleMakeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleMakers",
                keyColumn: "VehicleMakeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleMakers",
                keyColumn: "VehicleMakeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleMakers",
                keyColumn: "VehicleMakeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleMakers",
                keyColumn: "VehicleMakeId",
                keyValue: 5);
        }
    }
}
