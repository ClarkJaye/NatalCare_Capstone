using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;

public class ProfileServices : IProfileServices
{
    private readonly IIdentityUnitOfWork identityUnitOfWork;
    private readonly IAppUnitOfWork unitOfWork;

    public ProfileServices(IIdentityUnitOfWork identityUnitOfWork, IAppUnitOfWork unitOfWork)
    {
        this.identityUnitOfWork = identityUnitOfWork;
        this.unitOfWork = unitOfWork;
    }

    // Get all profiles
    public async Task<List<Role>> GetProfiles()
    {
        // Use RoleManager to get all roles
        var profiles = await identityUnitOfWork.RoleManager.Roles.ToListAsync();
        return profiles;
    }


    // Create a new profile
    public async Task<bool> Create(Role profile, string userId)
    {
        if (profile == null || string.IsNullOrEmpty(profile.Name))
        {
            return false;
        }

        var existingRole = await identityUnitOfWork.RoleManager.FindByNameAsync(profile.Name);
        if (existingRole != null)
        {
            return false;  // Role already exists
        }

        profile.RoleCreatedBy = userId;
        profile.Created_At = DateTime.Now;

        var result = await identityUnitOfWork.RoleManager.CreateAsync(profile);
        return result.Succeeded;
    }

    // Get profile by Id
    public async Task<Role> GetProfileById(string profileId)
    {
        var profile = await identityUnitOfWork.RoleManager.FindByIdAsync(profileId);
        return profile;
    }

    // Update profile
    public async Task<bool> UpdateProfile(Role profile, string userId)
    {
        var existingProfile = await identityUnitOfWork.RoleManager.FindByIdAsync(profile.Id);

        if (existingProfile == null)
        {
            return false; // Profile not found
        }

        existingProfile.Name = profile.Name;
        existingProfile.Description = profile.Description;
        existingProfile.RoleUpdatedBy = userId;
        existingProfile.Updated_At = DateTime.Now;

        var result = await identityUnitOfWork.RoleManager.UpdateAsync(existingProfile);
        return result.Succeeded;
    }

    // Delete profile
    public async Task<bool> Delete(string profileId, string userId)
    {
        var role = await identityUnitOfWork.RoleManager.FindByIdAsync(profileId);
        if (role == null)
        {
            return false;  // Role not found
        }

        role.RoleUpdatedBy = userId;
        role.Updated_At = DateTime.Now;

        var result = await identityUnitOfWork.RoleManager.DeleteAsync(role);
        return result.Succeeded;
    }


}
