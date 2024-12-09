using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatalCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateCFTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AOG",
                table: "ClinicalFaceSheet");

            migrationBuilder.DropColumn(
                name: "EDC",
                table: "ClinicalFaceSheet");

            migrationBuilder.DropColumn(
                name: "LMP",
                table: "ClinicalFaceSheet");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7293));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7596));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7599));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7600));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7601));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7602));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7644));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7648));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7650));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7651));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7657));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7658));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7660));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7661));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7716));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7744));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7745));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7452));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7458));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 4, 0, 6, 860, DateTimeKind.Local).AddTicks(7456));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AOG",
                table: "ClinicalFaceSheet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EDC",
                table: "ClinicalFaceSheet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LMP",
                table: "ClinicalFaceSheet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1485));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1489));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1491));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1531));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1534));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1536));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1537));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1539));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1542));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1544));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1546));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1547));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1549));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1589));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1592));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1594));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1597));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1611));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1628));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1630));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1631));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1632));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1313));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1317));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 20, 42, 41, 915, DateTimeKind.Local).AddTicks(1316));
        }
    }
}
