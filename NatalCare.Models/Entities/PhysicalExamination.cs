using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;

namespace NatalCare.Models.Entities
{
    public class PhysicalExamination : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? OBHistory { get; set; }
        [Column(TypeName = "decimal(5, 2)")] 
        public decimal? Weight { get; set; }
        public string? Height { get; set; }
        public string? BP { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? PulseRate { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? RespiratoryRate { get; set; }
        [Column(TypeName = "decimal(4, 1)")]
        public decimal? Temperature { get; set; }
        public bool Skin_Normal { get; set; } = false;
        public bool Skin_Pale { get; set; } = false;
        public bool Skin_Yellowish { get; set; } = false;
        public bool Skin_Hematoma { get; set; } = false;
        public bool Breast_Normal { get; set; } = false;
        public bool Breast_Mass { get; set; } = false;
        public bool Breast_NippleDischarged { get; set; } = false;
        public bool Conjunctive_Normal { get; set; } = false;
        public bool Conjunctive_Pale { get; set; } = false;
        public bool Conjunctive_YW { get; set; } = false;
        public bool Abdomen_Normal { get; set; } = false;
        public bool Abdomen_Mass { get; set; } = false;
        public bool Abdomen_Varicosities { get; set; } = false;
        public bool Neck_Normal { get; set; } = false;
        public bool Neck_Mass { get; set; } = false;
        public bool Neck_EnlargedLymphNodes { get; set; } = false;
        public bool Extremities_Normal { get; set; } = false;
        public bool Extremities_Edema { get; set; } = false;
        public bool Extremities_Varicosities { get; set; } = false;
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

        public DateTime? Created_At { get; set; }
        [Column("Created_By")]
        public string? PECreatedBy { get; set; }
        [ForeignKey("PECreatedBy")]
        [ValidateNever]
        public User? CreatedBy { get; set; }

        public DateTime? Updated_At { get; set; }
        [Column("Updated_By")]
        public string? PEUpdatedBy { get; set; }
        [ForeignKey("PEUpdatedBy")]
        [ValidateNever]
        public User? UpdatedBy { get; set; }

        public string? StatusCode { get; set; }
        [ForeignKey("StatusCode")]
        [ValidateNever]
        public Status? Status { get; set; }


    }
}
