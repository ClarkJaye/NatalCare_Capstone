using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatalCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTAbless : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClinicalFaceSheet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admission_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Admission_Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discharge_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discharge_Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalNoDays = table.Column<int>(type: "int", nullable: true),
                    LMP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EDC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AOG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clinical_T = table.Column<int>(type: "int", nullable: true),
                    Clinical_P = table.Column<int>(type: "int", nullable: true),
                    Clinical_A = table.Column<int>(type: "int", nullable: true),
                    Clinical_L = table.Column<int>(type: "int", nullable: true),
                    Gravida = table.Column<int>(type: "int", nullable: true),
                    Para = table.Column<int>(type: "int", nullable: true),
                    Abortion = table.Column<int>(type: "int", nullable: true),
                    HistoryOfPatientPresentCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Admitting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ICDCodes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalDiagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InformantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationToPatient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InformantAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InformantContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recoverred = table.Column<bool>(type: "bit", nullable: false),
                    Improved = table.Column<bool>(type: "bit", nullable: false),
                    UnImproved = table.Column<bool>(type: "bit", nullable: false),
                    Discarged = table.Column<bool>(type: "bit", nullable: false),
                    Transferred = table.Column<bool>(type: "bit", nullable: false),
                    Hama = table.Column<bool>(type: "bit", nullable: false),
                    Abssconded = table.Column<bool>(type: "bit", nullable: false),
                    MidwifeID = table.Column<int>(type: "int", nullable: true),
                    CaseNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    Created_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clinical = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StatusCode = table.Column<string>(type: "nvarchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalFaceSheet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClinicalFaceSheet_AspNetUsers_Clinical",
                        column: x => x.Clinical,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClinicalFaceSheet_AspNetUsers_Created_By",
                        column: x => x.Created_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClinicalFaceSheet_Delivery_CaseNo",
                        column: x => x.CaseNo,
                        principalTable: "Delivery",
                        principalColumn: "CaseNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicalFaceSheet_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicalFaceSheet_Staff_MidwifeID",
                        column: x => x.MidwifeID,
                        principalTable: "Staff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClinicalFaceSheet_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8649));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8883));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8889));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8891));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8892));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8951));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8954));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8958));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8962));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8964));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8968));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13,
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(9040));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(9045));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(9047));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(9050));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(9053));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(9055));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(9065));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(9086));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(9087));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(9089));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(9090));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8831));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 11, 23, 10, 26, 13, 915, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalFaceSheet_CaseNo",
                table: "ClinicalFaceSheet",
                column: "CaseNo");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalFaceSheet_Clinical",
                table: "ClinicalFaceSheet",
                column: "Clinical");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalFaceSheet_Created_By",
                table: "ClinicalFaceSheet",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalFaceSheet_MidwifeID",
                table: "ClinicalFaceSheet",
                column: "MidwifeID");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalFaceSheet_PatientID",
                table: "ClinicalFaceSheet",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalFaceSheet_StatusCode",
                table: "ClinicalFaceSheet",
                column: "StatusCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicalFaceSheet");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(460));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(626));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(631));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(632));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(633));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(673));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(675));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(676));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(677));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(678));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(679));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(682));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(683));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(684));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(685));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13,
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(688));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(776));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(779));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(780));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(783));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(806));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(807));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(809));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(810));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(811));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 11, 19, 12, 53, 35, 855, DateTimeKind.Local).AddTicks(590));
        }
    }
}
