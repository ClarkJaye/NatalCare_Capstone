using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NatalCare.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NatalCare.Models.Entities
{
    public class PatientPayments : BaseEntity
    {
        [Key]
        [Required]
        public int? PatientPaymentID { get; set; }
        [Required]
        public decimal? Amount { get; set; }

        public string? Payment_Method { get; set; }
       

        // Foreign Key
        [Required]
        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]
        [ValidateNever]
        public Patients? Patients { get; set; }

        [Required]
        public int? PaymentID { get; set; }
        [ForeignKey("PaymentID")]
        [ValidateNever]
        public Payments? Payments { get; set; }

        public DateTime? DatePaid{ get; set; }

    }
}
