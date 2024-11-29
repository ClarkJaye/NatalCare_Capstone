using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NatalCare_System.Controllers
{
    public class PrintController : BaseController<PrintController>
    {
        private readonly IPatientServices patientServices;

        public PrintController(IPatientServices patientServices, IModuleAccessServices moduleAccessServices) : base(moduleAccessServices)
        {
            this.patientServices = patientServices;
        }

        public async Task<IActionResult> PrintPatientForm(string id)
        {
            try
            {
                var response = await patientServices.GetInformation(id);
                if (response.PatientID != null)
                {
                    return Json(new { IsSuccess = true, PatientId = response.PatientID });
                }
                return Json(new { IsSuccess = false, Message = "There is an error, Ask the It support" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in PrintPatientForm action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }

        public async Task<IActionResult> Patient_Form(string id)
        {
            try
            {
                var response = await patientServices.GetInformation(id);
                if (response.PatientID != null)
                {
                    return View(response);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Patient_Form action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }

        }


    }
}
