using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatalCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Update_Staff1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Staff",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1668));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1734));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1735));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1736));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1736));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1737));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1753));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1755));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1757));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1758));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1759));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1761));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1781));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1782));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1785));

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "ModuleId", "CategoryId", "Created_At", "ModuleTitle", "StatusCode" },
                values: new object[] { 13, 5, new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1786), "Staff", "AC" });

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1808));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1811));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1818));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1819));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName", "MiddleName" },
                values: new object[] { "Shane", "Cruz", "Dela" });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName", "MiddleName" },
                values: new object[] { "Jane", "Salvador", "Salvi" });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName", "MiddleName" },
                values: new object[] { "Liza", "Ariesgado", "Aries" });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1714));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1717));

            migrationBuilder.InsertData(
                table: "Role_access",
                columns: new[] { "ModuleId", "RoleId", "Created_At", "OpenAccess" },
                values: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 11, 13, 17, 23, 39, 664, DateTimeKind.Local).AddTicks(1821), "Y" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" });

            migrationBuilder.DeleteData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13);

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Staff");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Staff",
                newName: "FullName");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4775));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4879));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4881));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4904));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4907));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4909));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4932));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4932));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4934));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4934));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4936));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4938));

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1,
                column: "FullName",
                value: "Shane Dela Cruz");

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2,
                column: "FullName",
                value: "Jane Salvi Salvador");

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3,
                column: "FullName",
                value: "Liza Aries Ariesgado");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 11, 13, 17, 10, 53, 937, DateTimeKind.Local).AddTicks(4859));
        }
    }
}
