using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NatalCare.DataAccess.Entities;

namespace NatalCare.Models.Entities
{
    public class Newborn : BaseEntity
    {
        [Key]
        [Required]
        public string? NewbornID { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        [Required]
        public string? Gender { get; set; }

        public string? Circumference { get; set; }

        public string? Head { get; set; }

        public string? Chest { get; set; }

        public string? Length { get; set; }

        public string? Temp { get; set; }

        public string? Weight { get; set; }

        public int? APGAR { get; set; }

        public string? Medication { get; set; }

        [Required]
        public DateOnly? DateofBirth { get; set; }

        [Required]
        public TimeOnly? TimeofBirth { get; set; }

        // Foreign Key
        public DateTime? Created_At { get; set; }
        [Column("Created_By")]
        public string? NewbornCreatedBy { get; set; }
        [ForeignKey("NewbornCreatedBy")]
        [ValidateNever]
        public User? CreatedBy { get; set; }

        public DateTime? Updated_At { get; set; }
        [Column("Updated_By")]
        public string? NewbornUpdatedBy { get; set; }
        [ForeignKey("NewbornUpdatedBy")]
        [ValidateNever]
        public User? UpdatedBy { get; set; }

        public string? StatusCode { get; set; }
        [ForeignKey("StatusCode")]
        [ValidateNever]
        public Status? Status { get; set; }

        public string? MotherID { get; set; }
        [ForeignKey("MotherID")]
        [ValidateNever]
        public Patients? Patient { get; set; }
    }
}
