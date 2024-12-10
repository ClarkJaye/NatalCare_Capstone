﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> PrintScreeningForm(string id)
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

        //Print Obstetrical 
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
                var response = await serviceServices.GetOBRecord(id);
                if (response.Item != null)
                {
                    return View(response.Item);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Obstetrical_Form action");
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


        public async Task<IActionResult> Natality_Form(DateOnly startDate, DateOnly endDate)
        {
            ViewData["startDate"] = startDate;
            ViewData["endDate"] = endDate;
            // Check access permissions
            if (!await CheckAccessAsync(9))
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            // Fetch newborn records
            var response = await newbornServices.GetAllNewborns(startDate, endDate);

            // Check if the service call was successful
            if (!response.IsSuccess)
            {
                TempData["Error"] = response.Message;
                return RedirectToAction("Natality", "Reports");
            }

            // Cast the returned data to the expected type
            var newborns = response.Item as IEnumerable<Newborn>;
            if (newborns == null)
            {
                TempData["Error"] = "Failed to process the newborn data.";
                return RedirectToAction("Natality", "Reports");
            }

            // Prepare the view model with necessary counts
            var viewModel = new NatalityReportVM
            {
                // Live births categorized by age group and gender
                Male_10_14 = newborns.Count(n =>
                    n.Gender == "Male" &&
                    n.Patient?.Birthdate.HasValue == true &&
                    CalculateAge(n.Patient.Birthdate.Value) >= 10 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 14),
                Female_10_14 = newborns.Count(n =>
                    n.Gender == "Female" &&
                    n.Patient?.Birthdate.HasValue == true &&
                    CalculateAge(n.Patient.Birthdate.Value) >= 10 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 14),
                Male_15_19 = newborns.Count(n =>
                    n.Gender == "Male" &&
                    n.Patient?.Birthdate.HasValue == true &&
                    CalculateAge(n.Patient.Birthdate.Value) >= 15 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 19),
                Female_15_19 = newborns.Count(n =>
                    n.Gender == "Female" &&
                    n.Patient?.Birthdate.HasValue == true &&
                    CalculateAge(n.Patient.Birthdate.Value) >= 15 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 19),
                Male_20_49 = newborns.Count(n =>
                    n.Gender == "Male" &&
                    n.Patient?.Birthdate.HasValue == true &&
                    CalculateAge(n.Patient.Birthdate.Value) >= 20 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 49),
                Female_20_49 = newborns.Count(n =>
                    n.Gender == "Female" &&
                    n.Patient?.Birthdate.HasValue == true &&
                    CalculateAge(n.Patient.Birthdate.Value) >= 20 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 49),

                // Total live births
                TotalLiveBirths = newborns.Count(),

                // Vaginal deliveries categorized by gender
                VaginalDeliveries = newborns.Count(n => n.DeliveryType == "vaginal"),
                VaginalMale_10_14 = newborns.Count(n => n.DeliveryType == "vaginal" && n.Gender == "Male" && CalculateAge(n.Patient.Birthdate.Value) >= 10 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 14),
                VaginalFemale_10_14 = newborns.Count(n => n.DeliveryType == "vaginal" && n.Gender == "Female" && CalculateAge(n.Patient.Birthdate.Value) >= 10 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 14),

                VaginalMale_15_19 = newborns.Count(n => n.DeliveryType == "vaginal" && n.Gender == "Male" && CalculateAge(n.Patient.Birthdate.Value) >= 15 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 19),
                VaginalFemale_15_19 = newborns.Count(n => n.DeliveryType == "vaginal" && n.Gender == "Female" && CalculateAge(n.Patient.Birthdate.Value) >= 15 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 19),

                VaginalMale_20_49 = newborns.Count(n => n.DeliveryType == "vaginal" && n.Gender == "Male" && CalculateAge(n.Patient.Birthdate.Value) >= 20 &&
                   CalculateAge(n.Patient.Birthdate.Value) <= 49),
                VaginalFemale_20_49 = newborns.Count(n => n.DeliveryType == "vaginal" && n.Gender == "Female" && CalculateAge(n.Patient.Birthdate.Value) >= 20 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 49),


                // CS deliveries categorized by gender
                CSDeliveries = newborns.Count(n => n.DeliveryType == "cs"),
                CSMale_10_14 = newborns.Count(n => n.DeliveryType == "cs" && n.Gender == "Male" && CalculateAge(n.Patient.Birthdate.Value) >= 10 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 14),
                CSFemale_10_14 = newborns.Count(n => n.DeliveryType == "cs" && n.Gender == "Female" && CalculateAge(n.Patient.Birthdate.Value) >= 10 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 14),

                CSMale_15_19 = newborns.Count(n => n.DeliveryType == "cs" && n.Gender == "Male" && CalculateAge(n.Patient.Birthdate.Value) >= 15 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 19),
                CSFemale_15_19 = newborns.Count(n => n.DeliveryType == "cs" && n.Gender == "Female" && CalculateAge(n.Patient.Birthdate.Value) >= 15 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 19),

                CSMale_20_49 = newborns.Count(n => n.DeliveryType == "cs" && n.Gender == "Male" && CalculateAge(n.Patient.Birthdate.Value) >= 20 &&
                   CalculateAge(n.Patient.Birthdate.Value) <= 49),
                CSFemale_20_49 = newborns.Count(n => n.DeliveryType == "cs" && n.Gender == "Female" && CalculateAge(n.Patient.Birthdate.Value) >= 20 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 49),


                // Deliveries attended by professionals
                AttendedByPhysicians = newborns.Count(n => n.PhysicianID.HasValue),
                PSMale_10_14 = newborns.Count(n => n.PhysicianID.HasValue && n.Gender == "Male" && CalculateAge(n.Patient.Birthdate.Value) >= 10 &&
                  CalculateAge(n.Patient.Birthdate.Value) <= 14),
                PSFemale_10_14 = newborns.Count(n => n.PhysicianID.HasValue && n.Gender == "Female" && CalculateAge(n.Patient.Birthdate.Value) >= 10 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 14),

                PSMale_15_19 = newborns.Count(n => n.PhysicianID.HasValue && n.Gender == "Male" && CalculateAge(n.Patient.Birthdate.Value) >= 15 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 19),
                PSFemale_15_19 = newborns.Count(n => n.PhysicianID.HasValue && n.Gender == "Female" && CalculateAge(n.Patient.Birthdate.Value) >= 15 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 19),

                PSMale_20_49 = newborns.Count(n => n.PhysicianID.HasValue && n.Gender == "Male" && CalculateAge(n.Patient.Birthdate.Value) >= 20 &&
                   CalculateAge(n.Patient.Birthdate.Value) <= 49),
                PSFemale_20_49 = newborns.Count(n => n.PhysicianID.HasValue && n.Gender == "Female" && CalculateAge(n.Patient.Birthdate.Value) >= 20 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 49),



                AttendedByMidwives = newborns.Count(n => n.MidwifeID.HasValue),
                MWMale_10_14 = newborns.Count(n => n.MidwifeID.HasValue && n.Gender == "Male" && CalculateAge(n.Patient.Birthdate.Value) >= 10 &&
                  CalculateAge(n.Patient.Birthdate.Value) <= 14),
                MWFemale_10_14 = newborns.Count(n => n.MidwifeID.HasValue && n.Gender == "Female" && CalculateAge(n.Patient.Birthdate.Value) >= 10 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 14),

                MWMale_15_19 = newborns.Count(n => n.MidwifeID.HasValue && n.Gender == "Male" && CalculateAge(n.Patient.Birthdate.Value) >= 15 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 19),
                MWFemale_15_19 = newborns.Count(n => n.MidwifeID.HasValue && n.Gender == "Female" && CalculateAge(n.Patient.Birthdate.Value) >= 15 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 19),

                MWMale_20_49 = newborns.Count(n => n.MidwifeID.HasValue && n.Gender == "Male" && CalculateAge(n.Patient.Birthdate.Value) >= 20 &&
                   CalculateAge(n.Patient.Birthdate.Value) <= 49),
                MWFemale_20_49 = newborns.Count(n => n.MidwifeID.HasValue && n.Gender == "Female" && CalculateAge(n.Patient.Birthdate.Value) >= 20 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 49),

                AttendedByNurses = newborns.Count(n => n.StaffID.HasValue), // Assuming Nurses are recorded in StaffID
                NurseMale_10_14 = newborns.Count(n => n.StaffID.HasValue && n.Gender == "Male" && CalculateAge(n.Patient.Birthdate.Value) >= 10 &&
               CalculateAge(n.Patient.Birthdate.Value) <= 14),
                NurseFemale_10_14 = newborns.Count(n => n.StaffID.HasValue && n.Gender == "Female" && CalculateAge(n.Patient.Birthdate.Value) >= 10 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 14),

                NurseMale_15_19 = newborns.Count(n => n.StaffID.HasValue && n.Gender == "Male" && CalculateAge(n.Patient.Birthdate.Value) >= 15 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 19),
                NurseFemale_15_19 = newborns.Count(n => n.StaffID.HasValue && n.Gender == "Female" && CalculateAge(n.Patient.Birthdate.Value) >= 15 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 19),

                NurseMale_20_49 = newborns.Count(n => n.StaffID.HasValue && n.Gender == "Male" && CalculateAge(n.Patient.Birthdate.Value) >= 20 &&
                   CalculateAge(n.Patient.Birthdate.Value) <= 49),
                NurseFemale_20_49 = newborns.Count(n => n.StaffID.HasValue && n.Gender == "Female" && CalculateAge(n.Patient.Birthdate.Value) >= 20 &&
                    CalculateAge(n.Patient.Birthdate.Value) <= 49),

                // Age category of mothers for deliveries
                FemaleMothersUnder20 = newborns.Count(n => n.Patient?.Gender == "Female" && n.Patient?.Birthdate.HasValue == true && CalculateAge(n.Patient.Birthdate.Value) < 20),
                FemaleMothers20To49 = newborns.Count(n => n.Patient?.Gender == "Female" && n.Patient?.Birthdate.HasValue == true && CalculateAge(n.Patient.Birthdate.Value) >= 20 && CalculateAge(n.Patient.Birthdate.Value) <= 49),
                FemaleMothersOver49 = newborns.Count(n => n.Patient?.Gender == "Female" && n.Patient?.Birthdate.HasValue == true && CalculateAge(n.Patient.Birthdate.Value) > 49),
            };

            return View(viewModel);
        }

        // Helper method to calculate age
        private int CalculateAge(DateOnly birthDate)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var age = today.Year - birthDate.Year;

            if (birthDate > today.AddYears(-age)) age--; // Adjust for birthdate after current date in the year
            return age;
        }


    }
}
