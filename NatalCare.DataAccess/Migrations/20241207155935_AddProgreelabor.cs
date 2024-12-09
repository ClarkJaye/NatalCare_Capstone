using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatalCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProgreelabor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaternalMonitoring",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BabyDateDelivered = table.Column<DateOnly>(type: "date", nullable: true),
                    BabyTimeDelivered = table.Column<TimeOnly>(type: "time", nullable: true),
                    Apgar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BabySex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BabyWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlacentaTimeDelivered = table.Column<TimeOnly>(type: "time", nullable: true),
                    PlacentaStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceProviderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    Created_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StatusCode = table.Column<string>(type: "nvarchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaternalMonitoring", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MaternalMonitoring_AspNetUsers_Created_By",
                        column: x => x.Created_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaternalMonitoring_AspNetUsers_Updated_By",
                        column: x => x.Updated_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaternalMonitoring_Delivery_CaseNo",
                        column: x => x.CaseNo,
                        principalTable: "Delivery",
                        principalColumn: "CaseNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaternalMonitoring_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaternalMonitoring_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
                });

            migrationBuilder.CreateTable(
                name: "ProgressLabor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Time = table.Column<TimeOnly>(type: "time", nullable: true),
                    Temperature = table.Column<decimal>(type: "decimal(4,1)", nullable: true),
                    BP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PulseRate = table.Column<int>(type: "int", nullable: true),
                    UterineContractionInterval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cervicaldilation = table.Column<decimal>(type: "decimal(4,1)", nullable: true),
                    BowStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FetalHeartTones = table.Column<int>(type: "int", nullable: true),
                    FetalHeartToneChar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresentingPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonitoringID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressLabor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProgressLabor_MaternalMonitoring_MonitoringID",
                        column: x => x.MonitoringID,
                        principalTable: "MaternalMonitoring",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2493));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2805));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2808));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2811));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2812));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2853));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2856));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2857));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2859));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2861));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2863));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2864));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2867));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13,
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2868));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2907));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2910));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2911));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2912));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2914));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2915));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2916));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2926));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2938));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2939));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2941));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2942));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2677));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 12, 7, 23, 59, 33, 13, DateTimeKind.Local).AddTicks(2681));

            migrationBuilder.CreateIndex(
                name: "IX_MaternalMonitoring_CaseNo",
                table: "MaternalMonitoring",
                column: "CaseNo");

            migrationBuilder.CreateIndex(
                name: "IX_MaternalMonitoring_Created_By",
                table: "MaternalMonitoring",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_MaternalMonitoring_PatientID",
                table: "MaternalMonitoring",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_MaternalMonitoring_StatusCode",
                table: "MaternalMonitoring",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_MaternalMonitoring_Updated_By",
                table: "MaternalMonitoring",
                column: "Updated_By");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressLabor_MonitoringID",
                table: "ProgressLabor",
                column: "MonitoringID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgressLabor");

            migrationBuilder.DropTable(
                name: "MaternalMonitoring");

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
    }
}
