using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatalCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProgressLabor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgressLabor_MaternalMonitoring_MonitoringID",
                table: "ProgressLabor");

            migrationBuilder.DropIndex(
                name: "IX_ProgressLabor_MonitoringID",
                table: "ProgressLabor");

            migrationBuilder.DropColumn(
                name: "MonitoringID",
                table: "ProgressLabor");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryID",
                table: "ProgressLabor",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RespiratoryRate",
                table: "ProgressLabor",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9014));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9018));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9020));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9023));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9074));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9078));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9081));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9085));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9087));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9132));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9136));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9140));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9142));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9213));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9217));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9220));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9221));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9223));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9228));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9244));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9264));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9267));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(9269));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(8810));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(8818));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 16, 13, 0, 188, DateTimeKind.Local).AddTicks(8816));

            migrationBuilder.CreateIndex(
                name: "IX_ProgressLabor_DeliveryID",
                table: "ProgressLabor",
                column: "DeliveryID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressLabor_Delivery_DeliveryID",
                table: "ProgressLabor",
                column: "DeliveryID",
                principalTable: "Delivery",
                principalColumn: "CaseNo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgressLabor_Delivery_DeliveryID",
                table: "ProgressLabor");

            migrationBuilder.DropIndex(
                name: "IX_ProgressLabor_DeliveryID",
                table: "ProgressLabor");

            migrationBuilder.DropColumn(
                name: "DeliveryID",
                table: "ProgressLabor");

            migrationBuilder.DropColumn(
                name: "RespiratoryRate",
                table: "ProgressLabor");

            migrationBuilder.AddColumn<int>(
                name: "MonitoringID",
                table: "ProgressLabor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 77, DateTimeKind.Local).AddTicks(9795));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(302));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(309));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(312));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(318));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(395));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(401));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(404));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(409));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(414));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(418));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(425));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(426));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(427));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13,
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(429));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(552));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(553));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(556));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(557));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(572));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(593));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(595));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(596));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(7));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(12));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 12, 8, 1, 21, 4, 78, DateTimeKind.Local).AddTicks(10));

            migrationBuilder.CreateIndex(
                name: "IX_ProgressLabor_MonitoringID",
                table: "ProgressLabor",
                column: "MonitoringID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressLabor_MaternalMonitoring_MonitoringID",
                table: "ProgressLabor",
                column: "MonitoringID",
                principalTable: "MaternalMonitoring",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
