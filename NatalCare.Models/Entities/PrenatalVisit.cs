using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;

namespace NatalCare.Models.Entities
{
    public class PrenatalVisit : BaseEntity
    {
        [Key]
        [Required]
        public int PrenatalVisitID { get; set; }
        public string? AOGWeek { get; set; }
        public string? Weight { get; set; }
        public string? BP { get; set; }
        public string? FH { get; set; }
        public string? FHT { get; set; }
        public string? Temp { get; set; }
        public string? CR { get; set; }
        public string? RR { get; set; }
        public string? PhysicalAssessment { get; set; }
        public string? Notes { get; set; }
        public string? RX { get; set; }
        public DateTime? DateVisit { get; set; }
        public DateTime? NextVisit { get; set; }


        // Foreign Key
        [Required]
        public string? CaseNo { get; set; }
        [ForeignKey("CaseNo")]
        public Prenatal? PrenatalCase { get; set; }

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
