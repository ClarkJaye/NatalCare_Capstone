using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;
using NatalCare.Models.ViewModel.Patient;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class ReportsController : BaseController<ReportsController>
    {
        private readonly INewbornServices newbornServices;

        public ReportsController(INewbornServices newbornServices, IModuleAccessServices moduleAccessServices)
         : base(moduleAccessServices)
        {
            this.newbornServices = newbornServices;
        }
        public async Task<IActionResult> Natality()
        {
            if (!await CheckAccessAsync(9)) // Natality Reports
            {
                return RedirectTo();
            }
            return View();
        }

        public async Task<IActionResult> Invoices()
        {
            if (!await CheckAccessAsync(10)) // Payment Reports
            {
                return RedirectTo();
            }
            return View();
        }


        public async Task<IActionResult> NatalityReport(DateOnly startDate, DateOnly endDate)
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
