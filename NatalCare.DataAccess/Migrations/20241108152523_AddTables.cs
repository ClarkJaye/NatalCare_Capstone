using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NatalCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleStaff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    StatusCode = table.Column<string>(type: "nvarchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_RoleStaff_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleStaff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staff_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
                });

            migrationBuilder.CreateTable(
                name: "NewbornHearing",
                columns: table => new
                {
                    HearingNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateVisit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HearingResults = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    NewbornID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    Created_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StatusCode = table.Column<string>(type: "nvarchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewbornHearing", x => x.HearingNo);
                    table.ForeignKey(
                        name: "FK_NewbornHearing_AspNetUsers_Created_By",
                        column: x => x.Created_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewbornHearing_AspNetUsers_Updated_By",
                        column: x => x.Updated_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewbornHearing_Newborn_NewbornID",
                        column: x => x.NewbornID,
                        principalTable: "Newborn",
                        principalColumn: "NewbornID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewbornHearing_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewbornHearing_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewbornHearing_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
                });

            migrationBuilder.CreateTable(
                name: "NewbornScreening",
                columns: table => new
                {
                    ScreeningNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateRegistration = table.Column<DateOnly>(type: "date", nullable: true),
                    TypeOfSample = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilterCardNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCollection = table.Column<DateOnly>(type: "date", nullable: true),
                    TimeOfCollection = table.Column<TimeOnly>(type: "time", nullable: true),
                    PlaceOfCollection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Feeding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specimen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BabyStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreeningResults = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataSampleSent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Courier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingNubmer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    NewbornID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StatusCode = table.Column<string>(type: "nvarchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewbornScreening", x => x.ScreeningNo);
                    table.ForeignKey(
                        name: "FK_NewbornScreening_AspNetUsers_Created_By",
                        column: x => x.Created_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewbornScreening_AspNetUsers_Updated_By",
                        column: x => x.Updated_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewbornScreening_Newborn_NewbornID",
                        column: x => x.NewbornID,
                        principalTable: "Newborn",
                        principalColumn: "NewbornID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewbornScreening_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewbornScreening_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewbornScreening_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(2930));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3266));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3269));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3271));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3272));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3274));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3372));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3374));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3378));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3380));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3381));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3383));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3385));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3387));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.InsertData(
                table: "RoleStaff",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Staff" },
                    { 2, "Midwife" },
                    { 3, "Physician" }
                });

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3465));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3469));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3471));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3472));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3474));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3476));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3478));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3479));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3499));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3525));

            migrationBuilder.InsertData(
                table: "Spouse",
                columns: new[] { "SpouseId", "Address", "Birthdate", "FirstName", "Gender", "LastName", "MiddleName", "Occupation" },
                values: new object[] { 1, "Tipolo, Mandaue City Cebu ", new DateOnly(1899, 1, 4), "Erina", "Female", "Souma", "Nakiri", "Fashion Designer" });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3172));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 23, 25, 20, 825, DateTimeKind.Local).AddTicks(3182));

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientID", "Address", "Birthdate", "BloodType", "CivilStatus", "Created_At", "Emergency_MobileNumber", "Emergency_Name", "FirstName", "Gender", "HasPhilHealth", "LastName", "MiddleName", "MobileNumber", "Occupation", "PHIC_NO", "Created_By", "Updated_By", "PlaceOfBirth", "Religion", "SpouseId", "StatusCode", "TeleNumber", "Updated_At" },
                values: new object[] { "PT0001", "Tipolo, Mandaue City Cebu ", new DateOnly(1998, 1, 4), "O+", "single", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09912356894", "Mardelita Calma", "Erina", "Female", false, "Souma", "Nakiri", "09317860939", "Fashion Designer", null, "223e5845-f58c-493f-b6b4-46ff3b18a332", null, "Bantayan Cebu City", "Catholic", 1, "AC", null, null });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "RoleId", "StaffName", "StatusCode" },
                values: new object[,]
                {
                    { 1, 1, "Shane", "AC" },
                    { 2, 2, "Jane", "AC" },
                    { 3, 3, "Liza", "AC" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewbornHearing_Created_By",
                table: "NewbornHearing",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_NewbornHearing_NewbornID",
                table: "NewbornHearing",
                column: "NewbornID");

            migrationBuilder.CreateIndex(
                name: "IX_NewbornHearing_PatientID",
                table: "NewbornHearing",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_NewbornHearing_StaffID",
                table: "NewbornHearing",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_NewbornHearing_StatusCode",
                table: "NewbornHearing",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_NewbornHearing_Updated_By",
                table: "NewbornHearing",
                column: "Updated_By");

            migrationBuilder.CreateIndex(
                name: "IX_NewbornScreening_Created_By",
                table: "NewbornScreening",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_NewbornScreening_NewbornID",
                table: "NewbornScreening",
                column: "NewbornID");

            migrationBuilder.CreateIndex(
                name: "IX_NewbornScreening_PatientID",
                table: "NewbornScreening",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_NewbornScreening_StaffID",
                table: "NewbornScreening",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_NewbornScreening_StatusCode",
                table: "NewbornScreening",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_NewbornScreening_Updated_By",
                table: "NewbornScreening",
                column: "Updated_By");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_RoleId",
                table: "Staff",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_StatusCode",
                table: "Staff",
                column: "StatusCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewbornHearing");

            migrationBuilder.DropTable(
                name: "NewbornScreening");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "RoleStaff");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: "PT0001");

            migrationBuilder.DeleteData(
                table: "Spouse",
                keyColumn: "SpouseId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ab63db-22b1-4656-93e8-6240c08c988c",
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5512));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5568));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5570));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5571));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5572));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5573));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 1,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5586));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 2,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5588));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 3,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5590));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 4,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5590));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 5,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5591));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 6,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5592));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 7,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5593));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 8,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5593));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 9,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5594));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 10,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5595));

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "ModuleId",
                keyValue: 11,
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5596));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 1, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5613));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 2, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5615));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 3, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5616));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 4, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5616));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 5, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5617));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 6, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5618));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 7, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5618));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 8, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5619));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 9, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 10, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "Role_access",
                keyColumns: new[] { "ModuleId", "RoleId" },
                keyValues: new object[] { 11, "18ab63db-22b1-4656-93e8-6240c08c988c" },
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5621));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "AC",
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5551));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "DL",
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5554));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusCode",
                keyValue: "IN",
                column: "Created_At",
                value: new DateTime(2024, 11, 8, 19, 12, 12, 294, DateTimeKind.Local).AddTicks(5554));
        }
    }
}
