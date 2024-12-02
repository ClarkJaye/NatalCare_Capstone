using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatalCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWardsBeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Wards");

            migrationBuilder.AddColumn<string>(
                name: "PatientID",
                table: "Beds",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8346));

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 1,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 2,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 3,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 4,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 5,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 6,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 7,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 8,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 9,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 10,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8876));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8878));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8880));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8941));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8946));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8951));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8954));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8956));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8961));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8963));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8964));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13,
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8967));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(9038));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(9042));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(9044));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(9045));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(9047));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(9048));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(9049));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(9077));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(9081));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8575));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8583));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 12, 2, 0, 20, 36, 623, DateTimeKind.Local).AddTicks(8582));

            migrationBuilder.CreateIndex(
                name: "IX_Beds_PatientID",
                table: "Beds",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_Patients_PatientID",
                table: "Beds",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_Patients_PatientID",
                table: "Beds");

            migrationBuilder.DropIndex(
                name: "IX_Beds_PatientID",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "Beds");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Wards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(1915));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2243));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2245));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2246));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2284));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2296));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2299));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2303));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13,
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2304));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2342));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2345));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2348));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2379));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2381));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2382));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2104));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 11, 30, 14, 22, 30, 109, DateTimeKind.Local).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAvailable",
                value: false);

            migrationBuilder.UpdateData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsAvailable",
                value: false);
        }
    }
}
