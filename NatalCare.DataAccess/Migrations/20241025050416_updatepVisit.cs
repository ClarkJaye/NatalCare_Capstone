using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatalCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatepVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrenatalVisit_Prenatal_CaseNo",
                table: "PrenatalVisit");

            migrationBuilder.AddColumn<string>(
                name: "PatientID",
                table: "PrenatalVisit",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4175));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4232));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4233));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4234));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4235));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4236));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4250));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4252));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4253));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4254));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4255));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4256));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4259));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4280));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4283));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4284));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4287));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4287));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4288));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4289));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4289));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4290));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 13, 4, 16, 342, DateTimeKind.Local).AddTicks(4219));

            migrationBuilder.CreateIndex(
                name: "IX_PrenatalVisit_PatientID",
                table: "PrenatalVisit",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_PrenatalVisit_Patients_PatientID",
                table: "PrenatalVisit",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrenatalVisit_Prenatal_CaseNo",
                table: "PrenatalVisit",
                column: "CaseNo",
                principalTable: "Prenatal",
                principalColumn: "CaseNo",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrenatalVisit_Patients_PatientID",
                table: "PrenatalVisit");

            migrationBuilder.DropForeignKey(
                name: "FK_PrenatalVisit_Prenatal_CaseNo",
                table: "PrenatalVisit");

            migrationBuilder.DropIndex(
                name: "IX_PrenatalVisit_PatientID",
                table: "PrenatalVisit");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "PrenatalVisit");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5723));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5781));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5782));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5783));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5783));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5802));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5807));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5807));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5808));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5809));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5811));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5840));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5857));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5859));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5860));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5861));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5861));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5862));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5863));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5864));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5864));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5865));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5866));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5765));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 10, 24, 17, 34, 21, 871, DateTimeKind.Local).AddTicks(5766));

            migrationBuilder.AddForeignKey(
                name: "FK_PrenatalVisit_Prenatal_CaseNo",
                table: "PrenatalVisit",
                column: "CaseNo",
                principalTable: "Prenatal",
                principalColumn: "CaseNo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
