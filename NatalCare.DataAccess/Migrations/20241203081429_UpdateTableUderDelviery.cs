using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatalCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableUderDelviery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DischargementForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompleteDiagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostpartumCareAndHygiene = table.Column<bool>(type: "bit", nullable: false),
                    Nutrition = table.Column<bool>(type: "bit", nullable: false),
                    IronFolate = table.Column<bool>(type: "bit", nullable: false),
                    BirthSpacingFamilyPlanning = table.Column<bool>(type: "bit", nullable: false),
                    DangerSignsMother = table.Column<bool>(type: "bit", nullable: false),
                    FollowUpVisitsMother = table.Column<bool>(type: "bit", nullable: false),
                    ExclusiveBreastFeeding = table.Column<bool>(type: "bit", nullable: false),
                    HygieneCordCareWarmth = table.Column<bool>(type: "bit", nullable: false),
                    SpecialAdviceLowBirthWeight = table.Column<bool>(type: "bit", nullable: false),
                    DangerSignsBaby = table.Column<bool>(type: "bit", nullable: false),
                    FollowUpVisitsBaby = table.Column<bool>(type: "bit", nullable: false),
                    FollowUpManagement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MidwifeID = table.Column<int>(type: "int", nullable: true),
                    PreparedBy = table.Column<int>(type: "int", nullable: true),
                    DeliveryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    Created_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StatusCode = table.Column<string>(type: "nvarchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DischargementForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DischargementForm_AspNetUsers_Created_By",
                        column: x => x.Created_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DischargementForm_AspNetUsers_Updated_By",
                        column: x => x.Updated_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DischargementForm_Delivery_CaseNo",
                        column: x => x.CaseNo,
                        principalTable: "Delivery",
                        principalColumn: "CaseNo");
                    table.ForeignKey(
                        name: "FK_DischargementForm_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DischargementForm_Staff_MidwifeID",
                        column: x => x.MidwifeID,
                        principalTable: "Staff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DischargementForm_Staff_PreparedBy",
                        column: x => x.PreparedBy,
                        principalTable: "Staff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DischargementForm_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
                });

            migrationBuilder.CreateTable(
                name: "Obstetrical",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstDayOfLastMenstrualCycle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorMensesDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FrequencyOfCycleEvery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaysMensesMonthly = table.Column<bool>(type: "bit", nullable: false),
                    AgesOfFirstMenses = table.Column<int>(type: "int", nullable: true),
                    BirthControlTheOfPregnancy = table.Column<bool>(type: "bit", nullable: false),
                    DateOfPositivePregnancyTest = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PregnancyTestDoneBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalNoOfPreg = table.Column<int>(type: "int", nullable: true),
                    NoOf_FullTerm = table.Column<int>(type: "int", nullable: true),
                    NoOf_Premature = table.Column<int>(type: "int", nullable: true),
                    NoOfAbortions = table.Column<int>(type: "int", nullable: true),
                    NoOfMiscarriages = table.Column<int>(type: "int", nullable: true),
                    NoOfD_CWithCarriagesPregnancy = table.Column<int>(type: "int", nullable: true),
                    NoOfPregnancy_TubalPregnancy = table.Column<int>(type: "int", nullable: true),
                    NoOfMultipleBirths = table.Column<int>(type: "int", nullable: true),
                    NoOfLiving = table.Column<int>(type: "int", nullable: true),
                    PregnancyMonthYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfWeeks = table.Column<int>(type: "int", nullable: true),
                    LaborLengthHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthWeigth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthSex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vaginal_CS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnesthesiaType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfDelivery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PretermLabor = table.Column<bool>(type: "bit", nullable: true),
                    ComplicationsOrComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Obstetrical", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Obstetrical_AspNetUsers_Created_By",
                        column: x => x.Created_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Obstetrical_AspNetUsers_Updated_By",
                        column: x => x.Updated_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Obstetrical_Delivery_CaseNo",
                        column: x => x.CaseNo,
                        principalTable: "Delivery",
                        principalColumn: "CaseNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Obstetrical_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Obstetrical_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(8952));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(8956));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(8959));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(8994));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9009));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9011));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9012));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9014));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9016));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9059));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9061));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9064));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9073));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9089));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9090));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9092));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9093));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(9094));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(8775));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 14, 27, 520, DateTimeKind.Local).AddTicks(8773));

            migrationBuilder.CreateIndex(
                name: "IX_DischargementForm_CaseNo",
                table: "DischargementForm",
                column: "CaseNo");

            migrationBuilder.CreateIndex(
                name: "IX_DischargementForm_Created_By",
                table: "DischargementForm",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_DischargementForm_MidwifeID",
                table: "DischargementForm",
                column: "MidwifeID");

            migrationBuilder.CreateIndex(
                name: "IX_DischargementForm_PatientID",
                table: "DischargementForm",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_DischargementForm_PreparedBy",
                table: "DischargementForm",
                column: "PreparedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DischargementForm_StatusCode",
                table: "DischargementForm",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_DischargementForm_Updated_By",
                table: "DischargementForm",
                column: "Updated_By");

            migrationBuilder.CreateIndex(
                name: "IX_Obstetrical_CaseNo",
                table: "Obstetrical",
                column: "CaseNo");

            migrationBuilder.CreateIndex(
                name: "IX_Obstetrical_Created_By",
                table: "Obstetrical",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Obstetrical_PatientID",
                table: "Obstetrical",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Obstetrical_StatusCode",
                table: "Obstetrical",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Obstetrical_Updated_By",
                table: "Obstetrical",
                column: "Updated_By");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DischargementForm");

            migrationBuilder.DropTable(
                name: "Obstetrical");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(3702));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4131));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4136));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4137));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4202));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4204));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4205));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4207));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4209));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4218));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 12,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 13,
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4222));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4382));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4387));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4389));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4391));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4411));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4429));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4430));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 12, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4431));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 13, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(3929));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(3936));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 12, 3, 16, 0, 48, 979, DateTimeKind.Local).AddTicks(3934));
        }
    }
}
