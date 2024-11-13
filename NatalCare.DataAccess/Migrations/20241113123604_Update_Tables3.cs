using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NatalCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Update_Tables3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewbornScreening_Staff_StaffID",
                table: "NewbornScreening");

            migrationBuilder.DropIndex(
                name: "IX_NewbornScreening_StaffID",
                table: "NewbornScreening");

            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "NewbornScreening");

            migrationBuilder.AddColumn<string>(
                name: "AttendingPractitioner",
                table: "NewbornScreening",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1558));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1668));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1671));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1672));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1673));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1674));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1675));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1676));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1677));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1678));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1678));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1680));

            migrationBuilder.InsertData(
                table: "RoleStaff",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 4, "Nurse" },
                    { 5, "Doctor" }
                });

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1699));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1702));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1704));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1704));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1705));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1706));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1707));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1708));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1708));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1709));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1710));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1711));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1622));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1627));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 20, 36, 3, 946, DateTimeKind.Local).AddTicks(1626));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleStaff",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoleStaff",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "AttendingPractitioner",
                table: "NewbornScreening");

            migrationBuilder.AddColumn<int>(
                name: "StaffID",
                table: "NewbornScreening",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9074));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9140));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9142));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9142));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9169));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9188));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9190));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9192));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9193));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9193));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9195));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9195));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9196));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9197));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9197));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9121));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 19, 33, 31, 917, DateTimeKind.Local).AddTicks(9120));

            migrationBuilder.CreateIndex(
                name: "IX_NewbornScreening_StaffID",
                table: "NewbornScreening",
                column: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_NewbornScreening_Staff_StaffID",
                table: "NewbornScreening",
                column: "StaffID",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
