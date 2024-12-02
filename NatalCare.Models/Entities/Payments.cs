using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NatalCare.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NatalCare.Models.Entities
{
    public class Payments : BaseEntity
    {
        [Key]
        [Required]
        public int? PaymentID { get; set; }
        public decimal? Total_Amount { get; set; }
        public decimal? Final_Amount { get; set; }
        [Required]
        public string? Payment_Status { get; set; }
        public decimal? Discount { get; set; }
        public decimal? PhilHealth_Deduction { get; set; }

        public string? Notes { get; set; }

        public DateOnly? BillDate { get; set; }

        public DateOnly? DueDate { get; set; }

        // Foreign Key
        [Required]
        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]
        [ValidateNever]
        public Patients? Patient { get; set; }




        public DateTime? Created_At { get; set; }
        [Column("Created_By")]
        public string? PatientCreatedBy { get; set; }
        [ForeignKey("PatientCreatedBy")]
        [ValidateNever]
        public User? CreatedBy { get; set; }

        public DateTime? Updated_At { get; set; }

        [Column("Updated_By")]
        public string? PatientUpdatedBy { get; set; }
        [ForeignKey("PatientUpdatedBy")]
        [ValidateNever]
        public User? UpdatedBy { get; set; }


        public int? StaffID { get; set; }
        [ForeignKey("StaffID")]
        [ValidateNever]
        public Staff? Staff { get; set; }
    }
}
