using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NatalCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class wad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                });

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
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Spouse",
                columns: table => new
                {
                    SpouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spouse", x => x.SpouseId);
                });

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
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    Emergency_MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasPhilHealth = table.Column<bool>(type: "bit", nullable: false),
                    PHIC_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: true),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    Created_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StatusCode = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    SpouseId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Patients_Spouse_SpouseId",
                        column: x => x.SpouseId,
                        principalTable: "Spouse",
                        principalColumn: "SpouseId");
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
                name: "FamilyPlanning",
                columns: table => new
                {
                    CaseNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NoOfLivingChild = table.Column<int>(type: "int", nullable: true),
                    PlanToHaveMoreChildren = table.Column<bool>(type: "bit", nullable: true),
                    MethodType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AverageMonthlyIncome = table.Column<double>(type: "float", nullable: true),
                    SpouseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateVisit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StatusCode = table.Column<string>(type: "nvarchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyPlanning", x => x.CaseNo);
                    table.ForeignKey(
                        name: "FK_FamilyPlanning_AspNetUsers_Created_By",
                        column: x => x.Created_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FamilyPlanning_AspNetUsers_Updated_By",
                        column: x => x.Updated_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FamilyPlanning_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyPlanning_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
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
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    TimeofBirth = table.Column<TimeOnly>(type: "time", nullable: false),
                    DeliveryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Length = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    HeadCircumference = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ChestCircumference = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    MidArmCircumference = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Temp = table.Column<decimal>(type: "decimal(4,1)", nullable: true),
                    Medication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APGAR = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    Created_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StatusCode = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    MotherID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FatherID = table.Column<int>(type: "int", nullable: true),
                    MidwifeID = table.Column<int>(type: "int", nullable: true),
                    PhysicianID = table.Column<int>(type: "int", nullable: true),
                    StaffID = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Newborn_Spouse_FatherID",
                        column: x => x.FatherID,
                        principalTable: "Spouse",
                        principalColumn: "SpouseId");
                    table.ForeignKey(
                        name: "FK_Newborn_Staff_MidwifeID",
                        column: x => x.MidwifeID,
                        principalTable: "Staff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Newborn_Staff_PhysicianID",
                        column: x => x.PhysicianID,
                        principalTable: "Staff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Newborn_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Newborn_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Final_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Payment_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PhilHealth_Deduction = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notorial_Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BillDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    Created_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StaffID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_AspNetUsers_Created_By",
                        column: x => x.Created_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_AspNetUsers_Updated_By",
                        column: x => x.Updated_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "Id");
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
                name: "NewbornHearing",
                columns: table => new
                {
                    HearingNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateVisit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HearingResults = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BabyStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttendingPractioner = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    DateVisit = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    AttendingPractitioner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_NewbornScreening_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
                });

            migrationBuilder.CreateTable(
                name: "ItemPayments",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    PhilHealthCovered = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPayments", x => new { x.ItemID, x.PaymentID });
                    table.ForeignKey(
                        name: "FK_ItemPayments_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPayments_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientPayments",
                columns: table => new
                {
                    PatientPaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Payment_Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    DatePaid = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientPayments", x => x.PatientPaymentID);
                    table.ForeignKey(
                        name: "FK_PatientPayments_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientPayments_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServicesPayments",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false),
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    PhilhealthCovered = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesPayments", x => new { x.ServiceID, x.PaymentID });
                    table.ForeignKey(
                        name: "FK_ServicesPayments_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicesPayments_Services_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Services",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    CaseNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date_Admitted = table.Column<DateOnly>(type: "date", nullable: true),
                    Time_Admitted = table.Column<TimeOnly>(type: "time", nullable: true),
                    Date_Discharged = table.Column<DateOnly>(type: "date", nullable: true),
                    WardNumber = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryStatusID = table.Column<int>(type: "int", nullable: false),
                    PrentalID = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Delivery", x => x.CaseNo);
                    table.ForeignKey(
                        name: "FK_Delivery_AspNetUsers_Created_By",
                        column: x => x.Created_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Delivery_AspNetUsers_Updated_By",
                        column: x => x.Updated_By,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Delivery_DeliveryStatus_DeliveryStatusID",
                        column: x => x.DeliveryStatusID,
                        principalTable: "DeliveryStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Delivery_Newborn_NewbornID",
                        column: x => x.NewbornID,
                        principalTable: "Newborn",
                        principalColumn: "NewbornID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Delivery_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Delivery_Prenatal_CaseNo",
                        column: x => x.CaseNo,
                        principalTable: "Prenatal",
                        principalColumn: "CaseNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Delivery_Status_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode");
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
                table: "DeliveryStatus",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "In-Labor" },
                    { 2, "Pospartum" },
                    { 3, "Discharged" },
                    { 4, "Referral" }
                });

            migrationBuilder.InsertData(
                table: "RoleStaff",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Staff" },
                    { 2, "Midwife" },
                    { 3, "Physician" },
                    { 4, "Nurse" },
                    { 5, "Doctor" }
                });

            migrationBuilder.InsertData(
                table: "Spouse",
                columns: new[] { "SpouseId", "Address", "Birthdate", "FirstName", "Gender", "LastName", "MiddleName", "Occupation" },
                values: new object[] { 1, "Tipolo, Mandaue City Cebu ", new DateOnly(1899, 1, 4), "Yukihira", "Female", "Souma", "Dela", "Enginneer" });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusCode", "Created_At", "StatusName" },
                values: new object[,]
                {
                    { "AC", new DateTime(2024, 12, 7, 13, 24, 35, 370, DateTimeKind.Local).AddTicks(9942), "ACTIVE" },
                    { "DL", new DateTime(2024, 12, 7, 13, 24, 35, 370, DateTimeKind.Local).AddTicks(9949), "DELETE" },
                    { "IN", new DateTime(2024, 12, 7, 13, 24, 35, 370, DateTimeKind.Local).AddTicks(9947), "INACTTIVE" }
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
                    { 1, "Masters", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(20), "AC" },
                    { 2, "Patient Management", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(23), "AC" },
                    { 3, "Billing & Payement", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(25), "AC" },
                    { 4, "Reports", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(26), "AC" },
                    { 5, "Maintenance", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(28), "AC" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName", "RoleId" },
                values: new object[,]
                {
                    { 1, "Shane", "Cruz", "Dela", 1 },
                    { 2, "Jane", "Salvador", "Salvi", 2 },
                    { 3, "Liza", "Ariesgado", "Aries", 3 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Created_At", "Description", "Discriminator", "Name", "NormalizedName", "Created_By", "Updated_By", "Updated_At" },
                values: new object[] { "18ab63db-22b1-4656-93e8-6240c08c988c", null, new DateTime(2024, 12, 7, 13, 24, 35, 370, DateTimeKind.Local).AddTicks(9717), "CRUD Anything", "Role", "Admin", "ADMIN", "223e5845-f58c-493f-b6b4-46ff3b18a332", null, null });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "ModuleId", "CategoryId", "Created_At", "ModuleTitle", "StatusCode" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(117), "Dashboard", "AC" },
                    { 2, 2, new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(121), "Patient Records", "AC" },
                    { 3, 2, new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(123), "Newborn Records", "AC" },
                    { 4, 2, new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(124), "Admission / In-Patient", "AC" },
                    { 5, 2, new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(127), "Out-Patient (OPD)", "AC" },
                    { 6, 2, new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(128), "Refferal Patient", "AC" },
                    { 7, 3, new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(130), "Invoice List", "AC" },
                    { 8, 3, new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(132), "Generate Invoice", "AC" },
                    { 9, 4, new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(134), "Natality Reports", "AC" },
                    { 10, 4, new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(136), "Invoice Reports", "AC" },
                    { 11, 5, new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(138), "Profiles", "AC" },
                    { 12, 5, new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(140), "Users", "AC" },
                    { 13, 5, new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(142), "Staff", "AC" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientID", "Address", "Birthdate", "BloodType", "CivilStatus", "Created_At", "Emergency_MobileNumber", "Emergency_Name", "FirstName", "Gender", "HasPhilHealth", "LastName", "MiddleName", "MobileNumber", "Occupation", "PHIC_NO", "Created_By", "Updated_By", "PlaceOfBirth", "Religion", "SpouseId", "StatusCode", "TeleNumber", "Updated_At" },
                values: new object[] { "PT0001", "Tipolo, Mandaue City Cebu ", new DateOnly(1998, 1, 4), "O+", "single", new DateTime(2024, 2, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "09912356894", "Mardelita Calma", "Erina", "Female", false, "Souma", "Nakiri", "09317860939", "Fashion Designer", null, "223e5845-f58c-493f-b6b4-46ff3b18a332", null, "Bantayan Cebu City", "Catholic", 1, "AC", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "18ab63db-22b1-4656-93e8-6240c08c988c", "223e5845-f58c-493f-b6b4-46ff3b18a332" });

            migrationBuilder.InsertData(
                table: "Role_access",
                columns: new[] { "ModuleId", "RoleId", "Created_At", "OpenAccess" },
                values: new object[,]
                {
                    { 1, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(217), "Y" },
                    { 2, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(220), "Y" },
                    { 3, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(221), "Y" },
                    { 4, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(223), "Y" },
                    { 5, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(225), "Y" },
                    { 6, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(226), "Y" },
                    { 7, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(228), "Y" },
                    { 8, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(248), "Y" },
                    { 9, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(267), "Y" },
                    { 10, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(270), "Y" },
                    { 11, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(271), "Y" },
                    { 12, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(273), "Y" },
                    { 13, "18ab63db-22b1-4656-93e8-6240c08c988c", new DateTime(2024, 12, 7, 13, 24, 35, 371, DateTimeKind.Local).AddTicks(275), "Y" }
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
                name: "IX_Delivery_Created_By",
                table: "Delivery",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_DeliveryStatusID",
                table: "Delivery",
                column: "DeliveryStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_NewbornID",
                table: "Delivery",
                column: "NewbornID");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_PatientID",
                table: "Delivery",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_StatusCode",
                table: "Delivery",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Updated_By",
                table: "Delivery",
                column: "Updated_By");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPlanning_Created_By",
                table: "FamilyPlanning",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPlanning_PatientID",
                table: "FamilyPlanning",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPlanning_StatusCode",
                table: "FamilyPlanning",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPlanning_Updated_By",
                table: "FamilyPlanning",
                column: "Updated_By");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPayments_PaymentID",
                table: "ItemPayments",
                column: "PaymentID");

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
                name: "IX_Newborn_FatherID",
                table: "Newborn",
                column: "FatherID");

            migrationBuilder.CreateIndex(
                name: "IX_Newborn_MidwifeID",
                table: "Newborn",
                column: "MidwifeID");

            migrationBuilder.CreateIndex(
                name: "IX_Newborn_MotherID",
                table: "Newborn",
                column: "MotherID");

            migrationBuilder.CreateIndex(
                name: "IX_Newborn_PhysicianID",
                table: "Newborn",
                column: "PhysicianID");

            migrationBuilder.CreateIndex(
                name: "IX_Newborn_StaffID",
                table: "Newborn",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Newborn_StatusCode",
                table: "Newborn",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Newborn_Updated_By",
                table: "Newborn",
                column: "Updated_By");

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
                name: "IX_NewbornScreening_StatusCode",
                table: "NewbornScreening",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_NewbornScreening_Updated_By",
                table: "NewbornScreening",
                column: "Updated_By");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPayments_PatientID",
                table: "PatientPayments",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPayments_PaymentID",
                table: "PatientPayments",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Created_By",
                table: "Patients",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_SpouseId",
                table: "Patients",
                column: "SpouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_StatusCode",
                table: "Patients",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Updated_By",
                table: "Patients",
                column: "Updated_By");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Created_By",
                table: "Payments",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PatientID",
                table: "Payments",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_StaffID",
                table: "Payments",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Updated_By",
                table: "Payments",
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

            migrationBuilder.CreateIndex(
                name: "IX_ServicesPayments_PaymentID",
                table: "ServicesPayments",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_RoleId",
                table: "Staff",
                column: "RoleId");
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
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "FamilyPlanning");

            migrationBuilder.DropTable(
                name: "ItemPayments");

            migrationBuilder.DropTable(
                name: "NewbornHearing");

            migrationBuilder.DropTable(
                name: "NewbornScreening");

            migrationBuilder.DropTable(
                name: "PatientPayments");

            migrationBuilder.DropTable(
                name: "PrenatalVisit");

            migrationBuilder.DropTable(
                name: "Role_access");

            migrationBuilder.DropTable(
                name: "ServicesPayments");

            migrationBuilder.DropTable(
                name: "DeliveryStatus");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Newborn");

            migrationBuilder.DropTable(
                name: "Prenatal");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Spouse");

            migrationBuilder.DropTable(
                name: "RoleStaff");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
