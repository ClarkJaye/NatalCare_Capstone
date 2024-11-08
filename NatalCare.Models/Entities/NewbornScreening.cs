using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NatalCare.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NatalCare.Models.Entities
{
    public class NewbornScreening : BaseEntity
    {
        [Key]
        [Required]
        public string? ScreeningNo { get; set; }
        public DateOnly? DateRegistration { get; set; }
        public string? TypeOfSample { get; set; }
        public string? FilterCardNo { get; set; }
        public string? BabyWeight { get; set; }
        public string? AOGWeek { get; set; }

        // Foreign Key
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
