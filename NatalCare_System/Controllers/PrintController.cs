using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;
using NatalCare.Models.ViewModel.Patient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NatalCare_System.Controllers
{
    public class PrintController : BaseController<PrintController>
    {
        private readonly IPatientServices patientServices;
        private readonly INewbornServices newbornServices;
        private readonly IServicesOperationServices serviceServices;

        public PrintController(IPatientServices patientServices, INewbornServices newbornServices, IServicesOperationServices serviceServices, IModuleAccessServices moduleAccessServices) : base(moduleAccessServices)
        {
            this.patientServices = patientServices;
                       this.newbornServices = newbornServices;
            this.serviceServices = serviceServices;
        }

        //Print Patient 
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

        //Print Newborn
        public async Task<IActionResult> PrintNewbornForm(string id)
        {
            try
            {
                var response = await newbornServices.GetInformation(id);
                if (response.Item != null)
                {
                    return Json(new { IsSuccess = true, Newborn = response.Item });
                }
                return Json(new { IsSuccess = false, Message = "There is an error, Ask the It support" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in PrintNewbornForm action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }
        public async Task<IActionResult> Newborn_Form(string id)
        {
            try
            {
                var response = await newbornServices.GetInformation(id);
                if (response.Item != null)
                {
                    return View(response.Item);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Patient_Form action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }

        }


        //Print Prenatal
        public async Task<IActionResult> PrintPrenatalForm(string id)
        {
            try
            {
                var response = await serviceServices.GetPrenatalInformation(id);
                if (response.CaseNo != null)
                {
                    return Json(new { IsSuccess = true, caseNo = response.CaseNo, patientId = response.PatientID});
                }
                return Json(new { IsSuccess = false, Message = "There is an error, Ask the It support" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in PrintPrenatalForm action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }
        public async Task<IActionResult> Prenatal_Form(string id, string patientId)
        {
            try
            {
                var prenatal = await serviceServices.GetPrenatalInformation(id);
                var prenatalVisit = await serviceServices.GetPrenatalVisitsRecords(id, patientId);
                if (prenatal.CaseNo != null)
                {
                    var viewModel = new PrenatalVM
                    {
                        Prenatal = prenatal,
                        PrenatalVisit = prenatalVisit
                    };
                    return View(viewModel);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Screening_Form action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }

        //Print Hearing
        public async Task<IActionResult> PrintHearingForm(string id)
        {
            try
            {
                var response = await serviceServices.GetHRRecordAsync(id);
                if (response.Item != null)
                {
                    return Json(new { IsSuccess = true, data = response.Item });
                }
                return Json(new { IsSuccess = false, Message = "There is an error, Ask the It support" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in PrintHearingForm action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }
        public async Task<IActionResult> Hearing_Form(string id)
        {
            try
            {
                var response = await serviceServices.GetHRFormPrint(id);
                if (response.Item != null)
                {
                    return View(response.Item);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Patient_Form action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }

        //Print Screening
        public async Task<IActionResult> PrinScreeningForm(string id)
        {
            try
            {
                var response = await serviceServices.GetScreeningFormPrint(id);
                if (response.Item != null)
                {
                    return Json(new { IsSuccess = true, data = response.Item });
                }
                return Json(new { IsSuccess = false, Message = "There is an error, Ask the It support" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in PrinScreeningForm action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }
        public async Task<IActionResult> Screening_Form(string id)
        {
            try
            {
                var response = await serviceServices.GetScreeningFormPrint(id);
                if (response.Item != null)
                {
                    return View(response.Item);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Screening_Form action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }


        //Print Dischargement
        public async Task<IActionResult> PrintDichargementForm(int id)
        {
            try
            {
                var response = await serviceServices.GetDFPrintForm(id);
                if (response.Id > 0)
                {
                    return Json(new { IsSuccess = true, dichargementId = response.Id });
                }
                return Json(new { IsSuccess = false, Message = "There is an error, Ask the It support" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in PrintDichargementForm action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }
        public async Task<IActionResult> Dischargement_Form(int id)
        {
            try
            {
                var response = await serviceServices.GetDFPrintForm(id);
                if (response.Id > 0)
                {
                    return View(response);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Screening_Form action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }



        //Print Physical Examination
        public async Task<IActionResult> PrintPEForm(int id)
        {
            try
            {
                var response = await serviceServices.GetPhysicalExaminationRecord(id);
                if (response.Item != null)
                {
                    return Json(new { IsSuccess = true, data = response.Item });
                }
                return Json(new { IsSuccess = false, Message = "There is an error, Ask the It support" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in PrintPEForm action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }
        public async Task<IActionResult> Examination_Form(int id)
        {
            try
            {
                var response = await serviceServices.GetPhysicalExaminationRecord(id);
                if (response.Item != null)
                {
                    return View(response.Item);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Examination_Form action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }


        //Print Clinical Sheet
        public async Task<IActionResult> PrintCFForm(int id)
        {
            try
            {
                var response = await serviceServices.GetCFPrintForm(id);
                if (response.ID > 0)
                {
                    return Json(new { IsSuccess = true, data = response.ID });
                }
                return Json(new { IsSuccess = false, Message = "There is an error, Ask the It support" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in PrintCFForm action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }
        public async Task<IActionResult> Clinical_Form(int id)
        {
            try
            {
                var response = await serviceServices.GetCFPrintForm(id);
                if (response.ID > 0)
                {
                    return View(response);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Clinical_Form action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }

        //Print Clinical Sheet
        public async Task<IActionResult> PrintObstetricalForm(int id)
        {
            try
            {
                var response = await serviceServices.GetOBRecord(id);
                if (response.Item != null)
                {
                    return Json(new { IsSuccess = true, data = response.Item });
                }
                return Json(new { IsSuccess = false, Message = "There is an error, Ask the It support" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in PrintObstetricalForm action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }
        public async Task<IActionResult> Obstetrical_Form(int id)
        {
            try
            {
                var response = await serviceServices.GetCFPrintForm(id);
                if (response.ID > 0)
                {
                    return View(response);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Clinical_Form action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }

        //Print MAternal Monitoring
        public async Task<IActionResult> PrintMaternalForm(string caseno)
        {
            try
            {
                var maternal = await serviceServices.GetMDPrintForm(caseno);
                if (maternal.ID > 0 )
                {
                    return Json(new { IsSuccess = true, maternal = maternal.CaseNo});
                }
                return Json(new { IsSuccess = false, Message = "There is an error, Ask the It support" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in PrintObstetricalForm action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }
        public async Task<IActionResult> MaternalMonitoring_Form(string caseno)
        {
            try
            {
                var maternal = await serviceServices.GetMDPrintForm(caseno);
                var progress = await serviceServices.GetPLPrintForm(caseno);
                if (maternal.ID > 0 || progress.Count() > 0)
                {
                    var viewModel = new MaternalMonitoringVM
                    {
                        MaternalMonitoring = maternal,
                        ProgressLabor = progress
                    };
                    return View(viewModel);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in MaternalMonitoring_Form action");
                return Json(new { IsSuccess = false, Message = "There is an error!" });
            }
        }
    }
}
