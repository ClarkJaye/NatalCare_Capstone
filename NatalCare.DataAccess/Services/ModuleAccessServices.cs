using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;

public class ModuleAccessServices : IModuleAccessServices
{
    private readonly IAppUnitOfWork _unitOfWork;

    public ModuleAccessServices(IAppUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Role_Access>> GetAccessibleModulesByRole(IList<string> roles)
    {


        var accessibleModules = await _unitOfWork.Repository<Role_Access>()
            .GetAllAsync2(
                ra => roles.Contains(ra.RoleId) && ra.OpenAccess == "Y" && ra.Module.StatusCode == "AC",
                include: query => query.Include(ra => ra.Module)
            );

        return accessibleModules.ToList(); // Return the entire Role_Access object
    }



}
