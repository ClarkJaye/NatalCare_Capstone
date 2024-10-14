using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;

public class ProfileAccessServices : IProfileAccessServices
{
    private readonly IIdentityUnitOfWork identityUnitOfWork;
    private readonly IAppUnitOfWork unitOfWork;

    public ProfileAccessServices(IIdentityUnitOfWork identityUnitOfWork, IAppUnitOfWork unitOfWork)
    {
        this.identityUnitOfWork = identityUnitOfWork;
        this.unitOfWork = unitOfWork;
    }

    // Get profile and its access by Id
    public async Task<(Role, List<Role_Access>)> GetProfileAndAccessById(string profileId)
    {
        // Fetch the role (profile) from RoleManager by its Id
        var role = await identityUnitOfWork.RoleManager.FindByIdAsync(profileId);

        if (role == null)
        {
            return (null, null);  // Role not found
        }

        // Fetch all modules to display
        var allModules = await unitOfWork.Repository<Modules>().GetAllAsync(); // Adjusted to use Modules

        // Fetch access information related to this role (profileId)
        var profileAccess = await unitOfWork.Repository<Role_Access>()
            .GetAllAsync(p => p.RoleId == profileId, includeProperties: "Module,Module.Category");

        // Create a combined list to ensure all modules are shown
        var combinedAccessList = allModules.Select(module => new Role_Access
        {
            Module = module,
            OpenAccess = profileAccess.FirstOrDefault(pa => pa.ModuleId == module.ModuleId)?.OpenAccess ?? "N", 
            RoleId = profileId 
        }).ToList();

        return (role, combinedAccessList);
    }

    // Update multiple access records
    public async Task UpdateAccess(List<Role_Access> profileAccessList)
    {
        // List to hold new Role_Access entries to be added
        var newAccessEntries = new List<Role_Access>();

        foreach (var access in profileAccessList)
        {
            var existingAccess = await unitOfWork.Repository<Role_Access>()
                .GetFirstOrDefaultAsync(p => p.RoleId == access.RoleId && p.ModuleId == access.ModuleId);

            if (existingAccess != null)
            {
                // Update existing access
                existingAccess.OpenAccess = access.OpenAccess; // "Y" or "N"
                unitOfWork.Repository<Role_Access>().Update(existingAccess);
            }
            else if (access.OpenAccess == "Y") // Only add if checking the box
            {
                // Create a new Role_Access entry
                var newAccess = new Role_Access
                {
                    RoleId = access.RoleId,
                    ModuleId = access.ModuleId,
                    OpenAccess = "Y"
                };
                newAccessEntries.Add(newAccess); // Add to the list for batch insertion
            }
        }

        // Now add all new access entries at once
        if (newAccessEntries.Any())
        {
            await unitOfWork.Repository<Role_Access>().AddRangeAsync(newAccessEntries);
        }

        // Save all changes to the database
        await unitOfWork.SaveAsync();
    }


}
