using NatalCare.Models.Entities;

namespace NatalCare.Models.ViewModel.Patient
{
    public class DeliveryRecordVM
    {
        public Patients? Patient { get; set; }
        public Delivery? Delivery { get; set; }
        public ClinicalFaceSheet? ClinicalSheetRecord { get; set; }         // Single clinical sheet records
        public Obstetrical? ObstetricalRecord { get; set; }                 // Single obstetrical records
        //public DeliveryMonitoring? DeliveryMonitoringRecord { get; set; } // Single monitoring records
        public PhysicalExamination? PhysicalExaminationRecord { get; set; } // Single Monitoring records
        public DischargemenForm? DischargemenFormRecord { get; set; }       // Single dischargement records
    }
}
