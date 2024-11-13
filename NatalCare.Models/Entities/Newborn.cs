using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NatalCare.DataAccess.Entities;

namespace NatalCare.Models.Entities
{
    public class Newborn : BaseEntity
    {
        [Key]
        public string? NewbornID { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        [Required]
        public string? Gender { get; set; }

        // Measurements
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? Weight { get; set; } // in grams

        [Column(TypeName = "decimal(5, 2)")]
        public decimal? Length { get; set; } // in cm

        [Column(TypeName = "decimal(5, 2)")] 
        public decimal? HeadCircumference { get; set; } // in cm

        [Column(TypeName = "decimal(5, 2)")]
        public decimal? ChestCircumference { get; set; } // in cm

        [Column(TypeName = "decimal(5, 2)")]
        public decimal? MidArmCircumference { get; set; } // in cm

        [Column(TypeName = "decimal(4, 1)")]
        public decimal? Temp { get; set; } // in °C
        public string? Medication { get; set; }

        [Range(0, 12)]
        public int? APGAR { get; set; }

        public string? PlaceOfBirth { get; set; }
        public string? Address { get; set; }

        [Required]
        public DateOnly? DateofBirth { get; set; }

        [Required]
        public TimeOnly? TimeofBirth { get; set; }

        // Foreign Key and Auditing Information
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
