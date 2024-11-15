using Microsoft.AspNetCore.Mvc.Rendering;
using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;

public class SelectListServices : ISelectListServices
{
    private readonly IAppUnitOfWork unitOfWork;

    public SelectListServices(IAppUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    //PRENATAL 
    public async Task<SelectList> GetAllNewbornSelectListAsync(string patientId)
    {
        var roles = await unitOfWork.Repository<Newborn>().GetAllAsync(x => x.MotherID == patientId);
        var staffWithFullNames = roles.Select(s => new
        {
            s.NewbornID,
            FullName = $"{s.LastName}, {(s.FirstName ?? "")} {s.MiddleName}".Trim()
        }).ToList();

        return new SelectList(staffWithFullNames, "NewbornID", "FullName");
    }


    //PRENATAL 
    public async Task<SelectList> GetAllPrenatalSelectListAsync(string patientId)
    {
        var roles = await unitOfWork.Repository<Prenatal>().GetAllAsync(x => x.PatientID == patientId);
        return new SelectList(roles, "CaseNo", "CaseNo");
    }

    //DELIVERY


    // STAFF
    public async Task<SelectList> GetAllStaffSelectListAsync()
    {
        var roles = await unitOfWork.Repository<Staff>().GetAllAsync(includeProperties: "RoleStaff");
        var staffWithFullNames = roles.Select(s => new
        {
            s.Id,
            FullName = $"{s.LastName}, {(s.FirstName ?? "")} {s.MiddleName}".Trim()
        }).ToList();

        return new SelectList(staffWithFullNames, "Id", "FullName");
    }

    public async Task<SelectList> GetStaffSelectListAsync()
    {
        var roles = await unitOfWork.Repository<Staff>().GetAllAsync(a=>a.RoleId == 1 , includeProperties: "RoleStaff");
        var staffWithFullNames = roles.Select(s => new
        {
            s.Id,
            FullName = $"{s.LastName}, {(s.FirstName ?? "")} {s.MiddleName}".Trim()
        }).ToList();

        return new SelectList(staffWithFullNames, "Id", "FullName");
    }

    public async Task<SelectList> GetMidwifeSelectListAsync()
    {
        var roles = await unitOfWork.Repository<Staff>().GetAllAsync(x => x.RoleId == 2, includeProperties: "RoleStaff");
        var staffWithFullNames = roles.Select(s => new
        {
            s.Id,
            FullName = $"{s.LastName}, {(s.FirstName ?? "")} {s.MiddleName}".Trim()
        }).ToList();
        return new SelectList(staffWithFullNames, "Id", "FullName");
    }
    public async Task<SelectList> GetPhysicianSelectListAsync()
    {
        var roles = await unitOfWork.Repository<Staff>().GetAllAsync(x => x.RoleId == 3, includeProperties: "RoleStaff");
        var staffWithFullNames = roles.Select(s => new
        {
            s.Id,
            FullName = $"{s.LastName}, {(s.FirstName ?? "")} {s.MiddleName}".Trim()
        }).ToList();
        return new SelectList(staffWithFullNames, "Id", "FullName");
    }

    public async Task<SelectList> GetNurseSelectListAsync()
    {
        var roles = await unitOfWork.Repository<Staff>().GetAllAsync(x => x.RoleId == 4, includeProperties: "RoleStaff");
        var staffWithFullNames = roles.Select(s => new
        {
            s.Id,
            FullName = $"{s.LastName}, {(s.FirstName ?? "")} {s.MiddleName}".Trim()
        }).ToList();
        return new SelectList(staffWithFullNames, "Id", "FullName");
    }

    public async Task<SelectList> GetDoctorSelectListAsync()
    {
        var roles = await unitOfWork.Repository<Staff>().GetAllAsync(x => x.RoleId == 5, includeProperties: "RoleStaff");
        var staffWithFullNames = roles.Select(s => new
        {
            s.Id,
            FullName = $"{s.LastName}, {(s.FirstName ?? "")} {s.MiddleName}".Trim()
        }).ToList();
        return new SelectList(staffWithFullNames, "Id", "FullName");
    }



    public async Task<SelectList> GetRoleStaffSelectListAsync()
    {
        var roles = await unitOfWork.Repository<RoleStaff>().GetAllAsync();
        return new SelectList(roles, "Id", "RoleName");
    }
    public async Task<SelectList> GetStatusCodeSelectListAsync()
    {
        var status = await unitOfWork.Repository<Status>().GetAllAsync();
        return new SelectList(status, "StatusCode", "StatusName");
    }

    public async Task<SelectList> GetDeliveryStatusSelectListAsync()
    {
        var status = await unitOfWork.Repository<DeliveryStatus>().GetAllAsync();
        return new SelectList(status, "Id", "StatusName");
    }




}
