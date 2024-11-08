using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NatalCare.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NatalCare.Models.Entities
{
    public class NewbornHearing : BaseEntity
    {
        [Key]
        [Required]
        public string? HearingNo { get; set; }
        public DateTime? DateVisit { get; set; }
        public string? HearingResults { get; set; }
        public DateOnly? TestDate{ get; set; }
        public string? Notes { get; set; }
        public string? BabyStatus { get; set; }
        

        // Foreign Key
        [Required]
        public int? StaffID { get; set; }
        [ForeignKey("StaffID")]
        [ValidateNever]
        public Staff? Staff { get; set; }

        [Required]
        public string? NewbornID { get; set; }
        [ForeignKey("NewbornID")]
        [ValidateNever]
        public Newborn? Newborn{ get; set; }

        [Required]
        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]
        [ValidateNever]
        public Patients? Patient { get; set; }

        public DateTime? Created_At { get; set; }
        [Column("Created_By")]
        public string? HearingCreatedBy { get; set; }
        [ForeignKey("HearingCreatedBy")]
        [ValidateNever]
        public User? CreatedBy { get; set; }

        public DateTime? Updated_At { get; set; }
        [Column("Updated_By")]
        public string? HearingUpdatedBy { get; set; }
        [ForeignKey("HearingUpdatedBy")]
        [ValidateNever]
        public User? UpdatedBy { get; set; }

        public string? StatusCode { get; set; }
        [ForeignKey("StatusCode")]
        [ValidateNever]
        public Status? Status { get; set; }
    }
}
