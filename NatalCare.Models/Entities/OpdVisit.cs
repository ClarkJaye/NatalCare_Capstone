using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;

namespace NatalCare.Models.Entities
{
    public class OpdVisit : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? DateVisit { get; set; }
        public string? ReasonForVisit { get; set; }

        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]
        [ValidateNever]
        public Patients? Patient { get; set; }

        public DateTime? Created_At { get; set; }
        [Column("Created_By")]
        public string? OPDCreatedBy { get; set; }
        [ForeignKey("OPDCreatedBy ")]
        [ValidateNever]
        public User? CreatedBy { get; set; }

        public string? StatusCode { get; set; }
        [ForeignKey("StatusCode")]
        [ValidateNever]
        public Status? Status { get; set; }
    }
}
