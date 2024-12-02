using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.data;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repositories;
using NatalCare.DataAccess.Repository;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.DataAccess.Services;
using NatalCare.Models.DTOs.VM;
using NatalCare.Models.Entities;
using PrinceQ.DataAccess.Hubs;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;

    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();



//builder.Services.AddScoped<IModuleAccessServices, ModuleAccessServices>();
//// Register Identity
//builder.Services.AddScoped<IIdentityUnitOfWork, IdentityUnitOfWork>();
//// Register Unit of Work
//builder.Services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
//// Register Patient 
//builder.Services.AddScoped<IPatientServices, PatientServices>();
//// Register Profile
//builder.Services.AddScoped<IProfileServices, ProfileServices>();
//// Register Profile Access
//builder.Services.AddScoped<IProfileAccessServices, ProfileAccessServices>();
//// Register Services CRUD Operations
//builder.Services.AddScoped<IServicesOperationServices, ServicesOperationServices>();
//// Register Newborn
//builder.Services.AddScoped<INewbornServices, NewbornServices>();
//// Register SelectList 
//builder.Services.AddScoped<ISelectListServices, SelectListServices>();

//builder.Services.AddScoped<IBillingServices, BillingServices>();

// Configure SecurityStampValidatorOptions for idle timeout
builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    options.ValidationInterval = TimeSpan.FromMinutes(30); 
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    //options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = true;
});

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapHub<NatalCareHub>("/NatalCare.DataAccess/hubs/natalCareHub");

app.Run();
