using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;

namespace NatalCare.Models.Entities
{
    public class ClinicalFaceSheet : BaseEntity
    {   
        [Key]
        public int ID { get; set; }
        public string? LMP { get; set; }
        public string? EDC { get; set; }
        public string? AOG { get; set; }
        public int? TermBirths { get; set; }
        public int? Premature { get; set; }
        public int? Abortion { get; set; }
        public int? LivingChildren { get; set; }
        public int? Gravida { get; set; }
        public int? Para { get; set; }
        public string? HistoryOfPatientPresentCondition{ get; set; }
        public string? Admitting { get; set; }
        public string? ICDCodes { get; set; }
        public string? FinalDiagnosis { get; set; }
        public string? InformantName { get; set; }
        public string? RelationToPatient { get; set; }
        public string? InformantAddress { get; set; }
        public string? InformantContactNo { get; set; }
        public bool Recoverred { get; set; } = false;
        public bool Improved { get; set; } = false;
        public bool UnImproved { get; set; } = false;
        public bool Discarged { get; set; } = false;
        public bool Transferred { get; set; } = false;
        public bool Hama { get; set; } = false;
        public bool Abssconded { get; set; } = false;



        // Foreign Key
        public int? MidwifeID { get; set; }
        [ForeignKey("MidwifeID")]
        [ValidateNever]
        public Staff? Midwife { get; set; }

        [Required]
        public string? CaseNo { get; set; }
        [ForeignKey("CaseNo")]
        public Delivery? Delivery { get; set; }

        // Foreign Key
        [Required]
        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]
        [ValidateNever]
        public Patients? Patient { get; set; }

        public DateTime? Created_At { get; set; }
        [Column("Created_By")]
        public string? ClinicalCreatedBy { get; set; }
        [ForeignKey("ClinicalCreatedBy")]
        [ValidateNever]
        public User? CreatedBy { get; set; }

        public DateTime? Updated_At { get; set; }
        [Column("Updated_By")]
        public string? ClinicalUpdatedBy { get; set; }
        [ForeignKey("Clinical")]
        [ValidateNever]
        public User? UpdatedBy { get; set; }

        public string? StatusCode { get; set; }
        [ForeignKey("StatusCode")]
        [ValidateNever]
        public Status? Status { get; set; }

    }
}
