using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NatalCare.Models.Entities;
using System.Data;

namespace NatalCare.DataAccess.data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Modules> Module { get; set; }
        public DbSet<Role_Access> Role_access { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Newborn> Newborn { get; set; }

        //Services
        public DbSet<Prenatal> Prenatal { get; set; }
        public DbSet<PrenatalVisit> PrenatalVisit { get; set; }
        public DbSet<FamilyPlanning> FamilyPlanning { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "223e5845-f58c-493f-b6b4-46ff3b18a332",
                    FirstName = "lisa",
                    MiddleName = "valiz",
                    LastName = "pdeuciano",
                    Address = "Mabolo Cebu City",
                    Birthdate = new DateOnly(1952, 06, 07),
                    Gender = "Female",
                    UserName = "lisa",
                    NormalizedUserName = "LISA",
                    Email = "lisa@paanakan.com",
                    NormalizedEmail = "LISA@PAANAKAN.COM",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    PasswordHash = "AQAAAAIAAYagAAAAEGyjgIyp14MszGz90Bkg/ySJenVsZL6A3jIS+/4y71OtVSvfM3TmPBf/I3ff0iGhqw==",
                    SecurityStamp = "RHHJPIOEKQH4HWQZLCOLOYY4E5RMLV2T",
                    ConcurrencyStamp = "035ccf9c-2337-4575-99af-795fac9481cd",
                    StatusCode = "AC"
                }
            );
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = "18ab63db-22b1-4656-93e8-6240c08c988c",
                    Description = "CRUD Anything",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    RoleCreatedBy = "223e5845-f58c-493f-b6b4-46ff3b18a332"
                }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "223e5845-f58c-493f-b6b4-46ff3b18a332",
                    RoleId = "18ab63db-22b1-4656-93e8-6240c08c988c"
                }
            );
            modelBuilder.Entity<Status>().HasData(
              new Status { StatusCode = "AC", StatusName = "ACTIVE" },
              new Status { StatusCode = "IN", StatusName = "INACTTIVE" },
              new Status { StatusCode = "DL", StatusName = "DELETE" }
            );
            modelBuilder.Entity<Category>().HasData(
              new Category { CategoryId = 1, CategoryName = "Masters", StatusCode = "AC" },
              new Category { CategoryId = 2, CategoryName = "Patient Management", StatusCode = "AC" },
              new Category { CategoryId = 3, CategoryName = "Billing & Payement", StatusCode = "AC" },
              new Category { CategoryId = 4, CategoryName = "Reports", StatusCode = "AC" },
              new Category { CategoryId = 5, CategoryName = "Maintenance", StatusCode = "AC" }
            );
            modelBuilder.Entity<Modules>().HasData(
              new Modules { ModuleId = 1, ModuleTitle = "Dashboard", CategoryId = 1, StatusCode = "AC"},
              new Modules { ModuleId = 2, ModuleTitle = "Patient Records", CategoryId = 2, StatusCode = "AC" },
              new Modules { ModuleId = 3, ModuleTitle = "Newborn Records", CategoryId = 2, StatusCode = "AC" },
              new Modules { ModuleId = 4, ModuleTitle = "Admission / In-Patient", CategoryId = 2, StatusCode = "AC" },
              new Modules { ModuleId = 5, ModuleTitle = "Out-Patient (OPD)", CategoryId = 2, StatusCode = "AC" },
              new Modules { ModuleId = 6, ModuleTitle = "Invoice List", CategoryId = 3, StatusCode = "AC" },
              new Modules { ModuleId = 7, ModuleTitle = "Generate Invoice", CategoryId = 3, StatusCode = "AC" },
              new Modules { ModuleId = 8, ModuleTitle = "Natality Reports", CategoryId = 4, StatusCode = "AC" },
              new Modules { ModuleId = 9, ModuleTitle = "Invoice Reports", CategoryId = 4, StatusCode = "AC" },
              new Modules { ModuleId = 10, ModuleTitle = "Profiles", CategoryId = 5, StatusCode = "AC" },
              new Modules { ModuleId = 11, ModuleTitle = "Users", CategoryId = 5, StatusCode = "AC" }
            );
            modelBuilder.Entity<Role_Access>().HasData(
             new Role_Access { RoleId = "18ab63db-22b1-4656-93e8-6240c08c988c", ModuleId = 1, OpenAccess = "Y"},
             new Role_Access { RoleId = "18ab63db-22b1-4656-93e8-6240c08c988c", ModuleId = 2, OpenAccess = "Y"},
             new Role_Access { RoleId = "18ab63db-22b1-4656-93e8-6240c08c988c", ModuleId = 3, OpenAccess = "Y"},
             new Role_Access { RoleId = "18ab63db-22b1-4656-93e8-6240c08c988c", ModuleId = 4, OpenAccess = "Y"},
             new Role_Access { RoleId = "18ab63db-22b1-4656-93e8-6240c08c988c", ModuleId = 5, OpenAccess = "Y"},
             new Role_Access { RoleId = "18ab63db-22b1-4656-93e8-6240c08c988c", ModuleId = 6, OpenAccess = "Y"},
             new Role_Access { RoleId = "18ab63db-22b1-4656-93e8-6240c08c988c", ModuleId = 7, OpenAccess = "Y"},
             new Role_Access { RoleId = "18ab63db-22b1-4656-93e8-6240c08c988c", ModuleId = 8, OpenAccess = "Y"},
             new Role_Access { RoleId = "18ab63db-22b1-4656-93e8-6240c08c988c", ModuleId = 9, OpenAccess = "Y"},
             new Role_Access { RoleId = "18ab63db-22b1-4656-93e8-6240c08c988c", ModuleId = 10, OpenAccess = "Y"},
             new Role_Access { RoleId = "18ab63db-22b1-4656-93e8-6240c08c988c", ModuleId = 11, OpenAccess = "Y"}
           );

            // For Junction 
            modelBuilder.Entity<Role_Access>()
                .HasKey(x => new { x.RoleId, x.ModuleId });

            // Default Date
            var entitiesWithCreatedAt = new[]
            {
                typeof(User),
                typeof(Role),
                typeof(Status),
                typeof(Role_Access),
                typeof(Patients),
                typeof(Newborn),
                typeof(Modules),
                typeof(Category),
                typeof(Prenatal),
                typeof(PrenatalVisit)
            };

            foreach (var entity in entitiesWithCreatedAt)
            {
                modelBuilder.Entity(entity)
                    .Property("Created_At")
                    .HasDefaultValueSql("GETDATE()");
            }

            modelBuilder.Entity<PrenatalVisit>()
                .HasOne(p => p.PrenatalCase)
                .WithMany()
                .HasForeignKey(p => p.CaseNo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PrenatalVisit>()
                .HasOne(p => p.Patient)
                .WithMany()
                .HasForeignKey(p => p.PatientID)
                .OnDelete(DeleteBehavior.Restrict);  

        }
    }
}
