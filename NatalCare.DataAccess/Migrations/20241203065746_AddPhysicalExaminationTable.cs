using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatalCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPhysicalExaminationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhysicalExamination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OBHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PulseRate = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    RespiratoryRate = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Temperature = table.Column<decimal>(type: "decimal(4,1)", nullable: true),
                    Skin_Normal = table.Column<bool>(type: "bit", nullable: false),
                    Skin_Pale = table.Column<bool>(type: "bit", nullable: false),
                    Skin_Yellowish = table.Column<bool>(type: "bit", nullable: false),
                    Skin_Hematoma = table.Column<bool>(type: "bit", nullable: false),
                    Breast_Normal = table.Column<bool>(type: "bit", nullable: false),
                    Breast_Mass = table.Column<bool>(type: "bit", nullable: false),
                    Breast_NippleDischarged = table.Column<bool>(type: "bit", nullable: false),
                    Conjunctive_Normal = table.Column<bool>(type: "bit", nullable: false),
                    Conjunctive_Pale = table.Column<bool>(type: "bit", nullable: false),
                    Conjunctive_YW = table.Column<bool>(type: "bit", nullable: false),
                    Abdomen_Normal = table.Column<bool>(type: "bit", nullable: false),
                    Abdomen_Mass = table.Column<bool>(type: "bit", nullable: false),
                    Abdomen_Varicosities = table.Column<bool>(type: "bit", nullable: false),
                    Neck_Mass = table.Column<bool>(type: "bit", nullable: false),
                    Neck_EnlargedLymphNodes = table.Column<bool>(type: "bit", nullable: false),
                    Extremities_Normal = table.Column<bool>(type: "bit", nullable: false),
                    Extremities_Edema = table.Column<bool>(type: "bit", nullable: false),
                    Extremities_Varicosities = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_PhysicalExamination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalExamination_AspNetUsers_Created_By",
                        column: x => x.Created_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhysicalExamination_AspNetUsers_Updated_By",
                        column: x => x.Updated_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhysicalExamination_Delivery_CaseNo",
                        column: x => x.CaseNo,
                        principalTable: "Delivery",
                        principalColumn: "CaseNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhysicalExamination_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhysicalExamination_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6381));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6385));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6387));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6389));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6433));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6437));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6439));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6440));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6442));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6443));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6566));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6568));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6572));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6573));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6574));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6584));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6596));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6597));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6598));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6259));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 14, 57, 44, 990, DateTimeKind.Local).AddTicks(6257));

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalExamination_CaseNo",
                table: "PhysicalExamination",
                column: "CaseNo");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalExamination_Created_By",
                table: "PhysicalExamination",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalExamination_PatientID",
                table: "PhysicalExamination",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalExamination_StatusCode",
                table: "PhysicalExamination",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalExamination_Updated_By",
                table: "PhysicalExamination",
                column: "Updated_By");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhysicalExamination");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3385));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3837));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3838));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3841));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3906));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3909));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3911));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3915));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3917));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3919));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3923));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3925));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3928));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3930));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3999));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(4010));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(4012));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(4030));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(4051));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3578));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3584));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 12, 52, 48, 712, DateTimeKind.Local).AddTicks(3582));
        }
    }
}
