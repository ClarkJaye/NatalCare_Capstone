using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;

namespace NatalCare.Models.Entities
{
    public class DischargementForm : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Hosp_No { get; set; }
        public string? CompleteDiagnosis { get; set; }
        public string? Medications { get; set; }
        public bool PostpartumCareAndHygiene { get; set; } = false;
        public bool Nutrition { get; set; } = false;
        public bool IronFolate { get; set; } = false;
        public bool BirthSpacingFamilyPlanning { get; set; } = false;
        public bool DangerSignsMother { get; set; } = false;
        public bool FollowUpVisitsMother { get; set; } = false;
        public bool ExclusiveBreastFeeding { get; set; } = false;
        public bool HygieneCordCareWarmth { get; set; } = false;
        public bool SpecialAdviceLowBirthWeight { get; set; } = false;
        public bool DangerSignsBaby { get; set; } = false;
        public bool FollowUpVisitsBaby { get; set; } = false;
        public string? FollowUpManagement { get; set; }
        public string? Notes { get; set; }

        // Foreign Key
        [Required]
        public string? CaseNo { get; set; }
        [ForeignKey("CaseNo")]
        public Delivery? Delivery { get; set; }

        [Required]
        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]
        [ValidateNever]
        public Patients? Patient { get; set; }

        ////ASSISTED STAFF
        public int? MidwifeID { get; set; }
        [ForeignKey("MidwifeID")]
        [ValidateNever]
        public Staff? Midwife { get; set; }

        public int? PreparedBy { get; set; }
        [ForeignKey("PreparedBy")]
        [ValidateNever]
        public Staff? Prepared { get; set; }

        public DateTime? Created_At { get; set; }
        [Column("Created_By")]
        public string? DeliveryCreatedBy { get; set; }
        [ForeignKey("DeliveryCreatedBy")]
        [ValidateNever]
        public User? CreatedBy { get; set; }

        public DateTime? Updated_At { get; set; }
        [Column("Updated_By")]
        public string? DeliveryUpdatedBy { get; set; }
        [ForeignKey("DeliveryUpdatedBy")]
        [ValidateNever]
        public User? UpdatedBy { get; set; }

        public string? StatusCode { get; set; }
        [ForeignKey("StatusCode")]
        [ValidateNever]
        public Status? Status { get; set; }

    }
}
