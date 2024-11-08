using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NatalCare.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NatalCare.Models.Entities
{
    public class Prenatal : BaseEntity
    {
        [Key]
        [Required]
        public string? CaseNo { get; set; }
        public string? Gravida { get; set; }
        public string? Para { get; set; }
        public string? Abortion { get; set; }
        public string? StillBirth { get; set; }
        public DateOnly? LMP { get; set; }
        public DateOnly? EDC { get; set; }
        public string? HRCODE { get; set; }
        public string? Notes { get; set; }
        public DateTime? DateVisit { get; set; }

        // Foreign Key
        [Required]
        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]
        [ValidateNever]
        public Patients? Patient { get; set; }

        public DateTime? Created_At { get; set; }
        [Column("Created_By")]
        public string? PrenatalCreatedBy { get; set; }
        [ForeignKey("PrenatalCreatedBy")]
        [ValidateNever]
        public User? CreatedBy { get; set; }

        public DateTime? Updated_At { get; set; }
        [Column("Updated_By")]
        public string? PrenatalUpdatedBy { get; set; }
        [ForeignKey("PrenatalUpdatedBy")]
        [ValidateNever]
        public User? UpdatedBy { get; set; }

        public string? StatusCode { get; set; }
        [ForeignKey("StatusCode")]
        [ValidateNever]
        public Status? Status { get; set; }
    }
}
