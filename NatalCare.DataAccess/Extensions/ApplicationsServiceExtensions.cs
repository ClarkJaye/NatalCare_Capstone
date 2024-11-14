using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Services;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.DataAccess.Repositories;
using NatalCare.DataAccess.Repository;

namespace NatalCare.DataAccess.Extensions
{
    public static class ApplicationsServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Register ModuleAccess
            services.AddScoped<IModuleAccessServices, ModuleAccessServices>();
            // Register Identity
            services.AddScoped<IIdentityUnitOfWork, IdentityUnitOfWork>();
            // Register Unit of Work
            services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
            // Register Patient 
            services.AddScoped<IPatientServices, PatientServices>();
            // Register Profile
            services.AddScoped<IProfileServices, ProfileServices>();
            // Register Profile Access
            services.AddScoped<IProfileAccessServices, ProfileAccessServices>();
            // Register Services CRUD Operations
            services.AddScoped<IServicesOperationServices, ServicesOperationServices>();
            // Register Newborn
            services.AddScoped<INewbornServices, NewbornServices>();
            // Register SelectList 
            services.AddScoped<ISelectListServices, SelectListServices>();

            // Register Newborn
            services.AddScoped<IBillingServices, BillingServices>();

            return services;
        }
    }
}
