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
        public DateOnly? Date_Admitted { get; set; }
        public TimeOnly? Time_Admitted { get; set; }
        public DateOnly? Date_Discharged { get; set; }
        public int? WardNumber { get; set; }
        public string? Notes { get; set; }
        
        // Foreign Key
        [Required]
        public int? DeliveryStatusID { get; set; }
        [ForeignKey("DeliveryStatusID")]
        [ValidateNever]
        public DeliveryStatus? DeliveryStatus { get; set; }

        [Required]
        public string? PrentalID { get; set; }
        [ForeignKey("PrentalID")]
        [ValidateNever]
        public Prenatal? Prenatal { get; set; }

        [Required]
        public string? NewbornID { get; set; }
        [ForeignKey("NewbornID")]
        [ValidateNever]
        public Newborn? Newborn { get; set; }

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
