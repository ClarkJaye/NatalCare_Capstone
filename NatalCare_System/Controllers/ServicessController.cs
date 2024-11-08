﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;


namespace NatalCare_System.Controllers
{
    [Authorize]
    public class ServicessController : BaseController<ServicessController>
    {
        private readonly IServicesOperationServices serviceServices;

        public ServicessController(IServicesOperationServices serviceServices)
        {
            this.serviceServices = serviceServices;
        }

        ////------ FAMILY PLANNING ------//
        ////Records
        //public async Task<IActionResult> FamilyPlanningRecords(string patientId)
        //{
        //    var familyPlanningRecords = await serviceServices.GetFamilyPlanningRecords(patientId);
        //    return ViewComponent("FamilyPlanningRecords", new { patientId = patientId });
        //}
        ////ADD 
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<JsonResult> AddFPRecord(FamilyPlanning model, string patientID)
        //{
        //    try
        //    {
        //        // Exclude CaseNo from validation
        //        ModelState.Remove(nameof(model.CaseNo));
        //        if (ModelState.IsValid)
        //        {
        //            var userId = GetCurrentUserId();
        //            var result = await serviceServices.AddFPRecordAsync(model, patientID, userId);
        //            return Json(result);
        //        }
        //        return Json(new { IsSuccess = false, Message = "Add Record failed!" });
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex, $"Error occurred while adding family planning record for Patient ID: {model.PatientID}");
        //        return Json(new { IsSuccess = false, Message = "An error occurred in AddPrenatalRecord." });
        //    }
        //}
        //// GET/EDIT 
        //[HttpGet]
        //public async Task<JsonResult> EditFPRecord(string caseNo)
        //{
        //    try
        //    {
        //        if (caseNo != null)
        //        {
        //            var userId = GetCurrentUserId();
        //            var result = await serviceServices.GetFPRecordAsync(caseNo);
        //            return Json(result);
        //        }
        //        return Json(new { IsSuccess = false, Message = "Fetching Record failed!" });
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex, $"Error occurred while Edit family planning record for Patient");
        //        return Json(new { IsSuccess = false, Message = "An error occurred in DeletePrenatalRecord." });
        //    }
        //}
        //// UPDATE
        //[HttpPost]
        //public async Task<JsonResult> UpdateFPRecord(FamilyPlanning model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var userId = GetCurrentUserId();
        //            var result = await serviceServices.UpdateFPRecordAsync(model, userId);
        //            return Json(result);
        //        }
        //        return Json(new { IsSuccess = false, Message = "Update Record failed!" });
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex, $"Error occurred while updating the family planning record for Patient ID: {model.PatientID}");
        //        return Json(new { IsSuccess = false, Message = "An error occurred in UpdatePrenatalRecord." });
        //    }
        //}
        //// DELETE 
        //[HttpDelete]
        //public async Task<JsonResult> DeleteFPRecord(string caseNo)
        //{
        //    try
        //    {
        //        if (caseNo != null)
        //        {
        //            var userId = GetCurrentUserId();
        //            var result = await serviceServices.DeleteFPRecordAsync(caseNo, userId);
        //            return Json(result);
        //        }
        //        return Json(new { IsSuccess = false, Message = "Delete Record failed!" });
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex, $"Error occurred while deleting family planning record for Patient");
        //        return Json(new { IsSuccess = false, Message = "An error occurred in DeleteFPRecord." });
        //    }
        //}

     

        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }
    }
}
