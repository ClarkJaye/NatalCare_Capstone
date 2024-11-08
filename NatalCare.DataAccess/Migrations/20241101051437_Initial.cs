using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NatalCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusCode);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusCode = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StatusCode = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    Created_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoles_AspNetUsers_Created_By",
                        column: x => x.Created_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetRoles_AspNetUsers_Updated_By",
                        column: x => x.Updated_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CivilStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeleNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emergency_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emergency_Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasPhilHealth = table.Column<bool>(type: "bit", nullable: true),
                    PHIC_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: true),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    Created_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StatusCode = table.Column<string>(type: "nvarchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patients_AspNetUsers_Created_By",
                        column: x => x.Created_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_AspNetUsers_Updated_By",
                        column: x => x.Updated_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    StatusCode = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ModuleId);
                    table.ForeignKey(
                        name: "FK_Module_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_Module_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Newborn",
                columns: table => new
                {
                    NewbornID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Circumference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Head = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APGAR = table.Column<int>(type: "int", nullable: true),
                    Medication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    TimeofBirth = table.Column<TimeOnly>(type: "time", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    Created_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StatusCode = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    MotherID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newborn", x => x.NewbornID);
                    table.ForeignKey(
                        name: "FK_Newborn_AspNetUsers_Created_By",
                        column: x => x.Created_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Newborn_AspNetUsers_Updated_By",
                        column: x => x.Updated_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Newborn_Patients_MotherID",
                        column: x => x.MotherID,
                        principalTable: "Patients",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_Newborn_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
                });

            migrationBuilder.CreateTable(
                name: "Prenatal",
                columns: table => new
                {
                    CaseNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Gravida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Para = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abortion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StillBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LMP = table.Column<DateOnly>(type: "date", nullable: true),
                    EDC = table.Column<DateOnly>(type: "date", nullable: true),
                    HRCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateVisit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    Created_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StatusCode = table.Column<string>(type: "nvarchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenatal", x => x.CaseNo);
                    table.ForeignKey(
                        name: "FK_Prenatal_AspNetUsers_Created_By",
                        column: x => x.Created_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prenatal_AspNetUsers_Updated_By",
                        column: x => x.Updated_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prenatal_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prenatal_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
                });

            migrationBuilder.CreateTable(
                name: "Role_access",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    OpenAccess = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_access", x => new { x.RoleId, x.ModuleId });
                    table.ForeignKey(
                        name: "FK_Role_access_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_access_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrenatalVisit",
                columns: table => new
                {
                    PrenatalVisitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AOGWeek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FHT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicalAssessment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateVisit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextVisit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberOfVisit = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_PrenatalVisit", x => x.PrenatalVisitID);
                    table.ForeignKey(
                        name: "FK_PrenatalVisit_AspNetUsers_Created_By",
                        column: x => x.Created_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrenatalVisit_AspNetUsers_Updated_By",
                        column: x => x.Updated_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrenatalVisit_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrenatalVisit_Prenatal_CaseNo",
                        column: x => x.CaseNo,
                        principalTable: "Prenatal",
                        principalColumn: "CaseNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrenatalVisit_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusCode", "Created_At", "StatusName" },
                values: new object[,]
                {
                    { "AC", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3057), "ACTIVE" },
                    { "IN", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3059), "INACTTIVE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StatusCode", "TwoFactorEnabled", "Updated_At", "UserName" },
                values: new object[] { "223e5845-f58c-493f-b6b4-46ff3b18a332", 0, "Mabolo Cebu City", new DateOnly(1952, 6, 7), "035ccf9c-2337-4575-99af-795fac9481cd", "lisa@paanakan.com", false, "lisa", "Female", "pdeuciano", true, null, "valiz", "LISA@PAANAKAN.COM", "LISA", "AQAAAAIAAYagAAAAEGyjgIyp14MszGz90Bkg/ySJenVsZL6A3jIS+/4y71OtVSvfM3TmPBf/I3ff0iGhqw==", null, false, "RHHJPIOEKQH4HWQZLCOLOYY4E5RMLV2T", "AC", false, null, "lisa" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName", "Created_At", "StatusCode" },
                values: new object[,]
                {
                    { 1, "Masters", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3079), "AC" },
                    { 2, "Patient Management", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3082), "AC" },
                    { 3, "Billing & Payement", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3083), "AC" },
                    { 4, "Reports", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3084), "AC" },
                    { 5, "Maintenance", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3085), "AC" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Created_At", "Description", "Discriminator", "Name", "NormalizedName", "Created_By", "Updated_By", "Updated_At" },
                values: new object[] { "18ab63db-22b1-4656-93e8-6240c08c988c", null, new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(2981), "CRUD Anything", "Role", "Admin", "ADMIN", "223e5845-f58c-493f-b6b4-46ff3b18a332", null, null });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "ModuleId", "CategoryId", "Created_At", "ModuleTitle", "StatusCode" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3107), "Dashboard", "AC" },
                    { 2, 2, new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3110), "Patient Records", "AC" },
                    { 3, 2, new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3111), "Newborn Records", "AC" },
                    { 4, 2, new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3112), "Admission / In-Patient", "AC" },
                    { 5, 2, new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3113), "Out-Patient (OPD)", "AC" },
                    { 6, 3, new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3114), "Invoice List", "AC" },
                    { 7, 3, new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3115), "Generate Invoice", "AC" },
                    { 8, 4, new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3116), "Natality Reports", "AC" },
                    { 9, 4, new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3117), "Invoice Reports", "AC" },
                    { 10, 5, new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3118), "Profiles", "AC" },
                    { 11, 5, new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3119), "Users", "AC" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "18ab63db-22b1-4656-93e8-6240c08c988c", "223e5845-f58c-493f-b6b4-46ff3b18a332" });

            migrationBuilder.InsertData(
                table: "Role_access",
                columns: new[] { "ModuleId", "RoleId", "Created_At", "OpenAccess" },
                values: new object[,]
                {
                    { 1, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3147), "Y" },
                    { 2, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3149), "Y" },
                    { 3, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3150), "Y" },
                    { 4, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3151), "Y" },
                    { 5, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3152), "Y" },
                    { 6, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3153), "Y" },
                    { 7, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3153), "Y" },
                    { 8, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3154), "Y" },
                    { 9, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3155), "Y" },
                    { 10, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3156), "Y" },
                    { 11, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 11, 1, 13, 14, 37, 169, DateTimeKind.Local).AddTicks(3158), "Y" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_Created_By",
                table: "AspNetRoles",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_Updated_By",
                table: "AspNetRoles",
                column: "Updated_By");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StatusCode",
                table: "AspNetUsers",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Category_StatusCode",
                table: "Category",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Module_CategoryId",
                table: "Module",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Module_StatusCode",
                table: "Module",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Newborn_Created_By",
                table: "Newborn",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Newborn_MotherID",
                table: "Newborn",
                column: "MotherID");

            migrationBuilder.CreateIndex(
                name: "IX_Newborn_StatusCode",
                table: "Newborn",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Newborn_Updated_By",
                table: "Newborn",
                column: "Updated_By");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Created_By",
                table: "Patients",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_StatusCode",
                table: "Patients",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Updated_By",
                table: "Patients",
                column: "Updated_By");

            migrationBuilder.CreateIndex(
                name: "IX_Prenatal_Created_By",
                table: "Prenatal",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Prenatal_PatientID",
                table: "Prenatal",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Prenatal_StatusCode",
                table: "Prenatal",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Prenatal_Updated_By",
                table: "Prenatal",
                column: "Updated_By");

            migrationBuilder.CreateIndex(
                name: "IX_PrenatalVisit_CaseNo",
                table: "PrenatalVisit",
                column: "CaseNo");

            migrationBuilder.CreateIndex(
                name: "IX_PrenatalVisit_Created_By",
                table: "PrenatalVisit",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_PrenatalVisit_PatientID",
                table: "PrenatalVisit",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PrenatalVisit_StatusCode",
                table: "PrenatalVisit",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_PrenatalVisit_Updated_By",
                table: "PrenatalVisit",
                column: "Updated_By");

            migrationBuilder.CreateIndex(
                name: "IX_Role_access_ModuleId",
                table: "Role_access",
                column: "ModuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Newborn");

            migrationBuilder.DropTable(
                name: "PrenatalVisit");

            migrationBuilder.DropTable(
                name: "Role_access");

            migrationBuilder.DropTable(
                name: "Prenatal");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
