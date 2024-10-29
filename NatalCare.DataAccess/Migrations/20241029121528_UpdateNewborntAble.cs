using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatalCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewborntAble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Newborn");

            migrationBuilder.AlterColumn<string>(
                name: "Weight",
                table: "Newborn",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Temp",
                table: "Newborn",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Length",
                table: "Newborn",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Head",
                table: "Newborn",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Circumference",
                table: "Newborn",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Chest",
                table: "Newborn",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Created_By",
                table: "Newborn",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Updated_By",
                table: "Newborn",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4370));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4430));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4434));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4451));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4452));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4453));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4455));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4457));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4458));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4480));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4480));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4484));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4411));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 10, 29, 20, 15, 27, 611, DateTimeKind.Local).AddTicks(4413));

            migrationBuilder.CreateIndex(
                name: "IX_Newborn_Created_By",
                table: "Newborn",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Newborn_Updated_By",
                table: "Newborn",
                column: "Updated_By");

            migrationBuilder.AddForeignKey(
                name: "FK_Newborn_AspNetUsers_Created_By",
                table: "Newborn",
                column: "Created_By",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Newborn_AspNetUsers_Updated_By",
                table: "Newborn",
                column: "Updated_By",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Newborn_AspNetUsers_Created_By",
                table: "Newborn");

            migrationBuilder.DropForeignKey(
                name: "FK_Newborn_AspNetUsers_Updated_By",
                table: "Newborn");

            migrationBuilder.DropIndex(
                name: "IX_Newborn_Created_By",
                table: "Newborn");

            migrationBuilder.DropIndex(
                name: "IX_Newborn_Updated_By",
                table: "Newborn");

            migrationBuilder.DropColumn(
                name: "Created_By",
                table: "Newborn");

            migrationBuilder.DropColumn(
                name: "Updated_By",
                table: "Newborn");

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Newborn",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Temp",
                table: "Newborn",
                type: "decimal(5,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Length",
                table: "Newborn",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Head",
                table: "Newborn",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Circumference",
                table: "Newborn",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Chest",
                table: "Newborn",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Newborn",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2201));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2224));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2254));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2254));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2255));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2255));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2256));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 10, 25, 16, 4, 51, 55, DateTimeKind.Local).AddTicks(2160));
        }
    }
}
