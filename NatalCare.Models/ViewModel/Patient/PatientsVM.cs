using NatalCare.Models.Entities;
using System.Collections.Generic;

namespace NatalCare.Models.ViewModel.Patient
{
    public class PatientsVM
    {
        public Patients? Patient { get; set; }              // Single patient record
        public List<Patients>? PatientList { get; set; }    // List of patients
        public Invoice? PrenatalRecord { get; set; }       // Single prenatal records
        public List<Prenatal>? PrenatalRecords { get; set; }   // List of prenatal records
    }
}
