using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatalCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientTalble2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Spouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4214));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4669));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4670));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4671));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4673));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4716));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4718));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4719));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4724));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4775));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4776));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4778));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4779));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4781));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4807));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4808));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4811));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "Spouse",
                keyColumn: "SpouseId",
                keyValue: 1,
                column: "Nationality",
                value: null);

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4517));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4524));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 36, 15, 173, DateTimeKind.Local).AddTicks(4523));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Spouse");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(3605));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(3945));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(3949));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(3951));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(3952));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(3991));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(3995));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(3998));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4001));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4004));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4010));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13,
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4011));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4059));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4061));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4062));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4072));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4087));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4088));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(4091));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(3719));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(3724));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 12, 4, 14, 23, 13, 252, DateTimeKind.Local).AddTicks(3723));
        }
    }
}
