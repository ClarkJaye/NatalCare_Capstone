using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;
using NatalCare.Models.ViewModel;
using static NatalCare.DataAccess.Response.ServiceResponses;

public class ProfileServices : IProfileServices
{
    private readonly IIdentityUnitOfWork identityUnitOfWork;
    private readonly IAppUnitOfWork unitOfWork;

    public ProfileServices(IIdentityUnitOfWork identityUnitOfWork, IAppUnitOfWork unitOfWork)
    {
        this.identityUnitOfWork = identityUnitOfWork;
        this.unitOfWork = unitOfWork;
    }

    //-----STAFF-------//

    public async Task<List<Staff>> GetAllStaff()
    {
        var staffs = await unitOfWork.Repository<Staff>().GetAllAsync(includeProperties: "RoleStaff");
        return staffs.ToList();
    }
    public async Task<bool> CreateStaff(Staff staff)
    {
        // Validation checks
        if (await unitOfWork.Repository<Staff>().AnyAsync(x => x.Id == staff.Id))
            throw new ArgumentException("Record already exists!");

        unitOfWork.Repository<Staff>().Add(staff);
        return await unitOfWork.SaveAsync() > 0;
    }
    public async Task<CommonResponse> DeleteStaff(int id)
    {
        var item = await unitOfWork.Repository<Staff>().GetFirstOrDefaultAsync(x => x.Id == id);
        if (item == null) return new CommonResponse(false, "Record not existing.");

        unitOfWork.Repository<Staff>().Remove(item);
        await unitOfWork.SaveAsync();
        return new CommonResponse(true, "Record deleted successfully");
    }
    public async Task<Staff> GetStaffById(int id)
    {
        var staff = await unitOfWork.Repository<Staff>().GetFirstOrDefaultAsync(s => s.Id == id);
        if(staff == null) return null;

        return staff;
    }
    // Update profile
    public async Task<bool> UpdateStaff(Staff staff)
    {
        var existingStaff = await unitOfWork.Repository<Staff>().GetFirstOrDefaultAsync(s => s.Id == staff.Id);

        if (existingStaff == null)
        {
            return false; 
        }

        existingStaff.FirstName = staff.FirstName;
        existingStaff.MiddleName = staff.MiddleName;
        existingStaff.LastName = staff.LastName;
        existingStaff.RoleId = staff.RoleId;

        unitOfWork.Repository<Staff>().Update(existingStaff);
        return await unitOfWork.SaveAsync() > 0;
    }



    //-----PROFILES-------//

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
