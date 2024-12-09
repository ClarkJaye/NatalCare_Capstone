using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;

public class ModuleAccessServices : IModuleAccessServices
{
    private readonly IAppUnitOfWork _unitOfWork;
    private readonly UserManager<User> userManager;
    private readonly RoleManager<Role> roleManager;
    public ModuleAccessServices(IAppUnitOfWork unitOfWork, UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _unitOfWork = unitOfWork;
        this.userManager = userManager;
        this.roleManager = roleManager;
    }

    public UserManager<User> UserManager => userManager;
    public RoleManager<Role> RoleManager => roleManager;

    public async Task<bool> HasAccessToModule(string roleId, int moduleId)
    {
        var hasAccess = await _unitOfWork.Repository<Role_Access>()
            .GetAllAsync2(  
                ra => ra.RoleId == roleId && ra.Module.ModuleId == moduleId && ra.OpenAccess == "Y",
                include: query => query.Include(ra => ra.Module)
            );
        return hasAccess.Any();
    }

    public async Task<List<Role_Access>> GetAccessibleModulesByRole(IList<string> roles)
    {
        var accessibleModules = await _unitOfWork.Repository<Role_Access>()
            .GetAllAsync2(
                ra => roles.Contains(ra.RoleId) && ra.OpenAccess == "Y" && ra.Module.StatusCode == "AC",
                include: query => query.Include(ra => ra.Module)
            );
        return accessibleModules.ToList();
    }



}
