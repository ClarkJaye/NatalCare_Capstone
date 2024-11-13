using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatalCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Updatenewborn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryType",
                table: "Newborn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MidwifeID",
                table: "Newborn",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhysicianID",
                table: "Newborn",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffID",
                table: "Newborn",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3511));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3513));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3514));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3557));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3560));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3561));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3562));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3563));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3563));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3564));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3566));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3566));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3567));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3589));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3591));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3592));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3593));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3593));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3594));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3595));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3595));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3596));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3598));

            migrationBuilder.UpdateData(
                table: "Spouse",
                keyColumn: "SpouseId",
                keyValue: 1,
                columns: new[] { "FirstName", "MiddleName", "Occupation" },
                values: new object[] { "Yukihira", "Dela", "Enginneer" });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3490));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 5, 6, 91, DateTimeKind.Local).AddTicks(3493));

            migrationBuilder.CreateIndex(
                name: "IX_Newborn_MidwifeID",
                table: "Newborn",
                column: "MidwifeID");

            migrationBuilder.CreateIndex(
                name: "IX_Newborn_PhysicianID",
                table: "Newborn",
                column: "PhysicianID");

            migrationBuilder.CreateIndex(
                name: "IX_Newborn_StaffID",
                table: "Newborn",
                column: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_Newborn_Staff_MidwifeID",
                table: "Newborn",
                column: "MidwifeID",
                principalTable: "Staff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Newborn_Staff_PhysicianID",
                table: "Newborn",
                column: "PhysicianID",
                principalTable: "Staff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Newborn_Staff_StaffID",
                table: "Newborn",
                column: "StaffID",
                principalTable: "Staff",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Newborn_Staff_MidwifeID",
                table: "Newborn");

            migrationBuilder.DropForeignKey(
                name: "FK_Newborn_Staff_PhysicianID",
                table: "Newborn");

            migrationBuilder.DropForeignKey(
                name: "FK_Newborn_Staff_StaffID",
                table: "Newborn");

            migrationBuilder.DropIndex(
                name: "IX_Newborn_MidwifeID",
                table: "Newborn");

            migrationBuilder.DropIndex(
                name: "IX_Newborn_PhysicianID",
                table: "Newborn");

            migrationBuilder.DropIndex(
                name: "IX_Newborn_StaffID",
                table: "Newborn");

            migrationBuilder.DropColumn(
                name: "DeliveryType",
                table: "Newborn");

            migrationBuilder.DropColumn(
                name: "MidwifeID",
                table: "Newborn");

            migrationBuilder.DropColumn(
                name: "PhysicianID",
                table: "Newborn");

            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "Newborn");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(503));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(526));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(530));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(531));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(532));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(533));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(533));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(534));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(535));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(536));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(536));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(537));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(538));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(593));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(597));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(597));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(598));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(599));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(599));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(601));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(602));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(602));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(603));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(604));

            migrationBuilder.UpdateData(
                table: "Spouse",
                keyColumn: "SpouseId",
                keyValue: 1,
                columns: new[] { "FirstName", "MiddleName", "Occupation" },
                values: new object[] { "Erina", "Nakiri", "Fashion Designer" });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(485));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(488));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 15, 39, 8, 280, DateTimeKind.Local).AddTicks(487));
        }
    }
}
