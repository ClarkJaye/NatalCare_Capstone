using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NatalCare.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NatalCare.Models.Entities
{
    public class Delivery : BaseEntity
    {
        [Key]
        [Required]
        public string? CaseNo { get; set; }

        // Essential Family Planning Fields
        public int? NoOfLivingChild { get; set; }
        public bool? PlanToHaveMoreChildren { get; set; }
        public string? MethodType { get; set; }
        public double? AverageMonthlyIncome { get; set; }
        public string? SpouseName { get; set; }
        public string? SpouseOccupation { get; set; }
        public DateTime? DateVisit { get; set; }
        public string? Notes { get; set; }


        // Foreign Key
        [Required]
        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]
        [ValidateNever]
        public Patients? Patient { get; set; }

        // Tracking Columns
        public DateTime? Created_At { get; set; }
        [Column("Created_By")]
        public string? DLCreatedBy { get; set; }
        [ForeignKey("DLCreatedBy")]
        [ValidateNever]
        public User? CreatedBy { get; set; }

        public DateTime? Updated_At { get; set; }
        [Column("Updated_By")]
        public string? DLUpdatedBy { get; set; }
        [ForeignKey("DLUpdatedBy")]
        [ValidateNever]
        public User? UpdatedBy { get; set; }

        public string? StatusCode { get; set; }
        [ForeignKey("StatusCode")]
        [ValidateNever]
        public Status? Status { get; set; }
    }
}
