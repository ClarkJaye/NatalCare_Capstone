using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.ViewComponents
{
    public class PatientsRecordsViewComponent : ViewComponent
    {
        private readonly IPatientServices patientServices;

        public PatientsRecordsViewComponent(IPatientServices patientServices)
        {
            this.patientServices = patientServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var records = await patientServices.GetPatients();
            return View(records);
        }
    }
}
