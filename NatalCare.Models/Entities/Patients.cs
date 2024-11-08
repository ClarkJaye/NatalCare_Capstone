using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatalCare.Models.Entities
{
    public class Patients : BaseEntity
    {
        [Key]
        public string? PatientID { get; set; }
        [StringLength(100)]
        public string? FirstName { get; set; }
        [StringLength(100)]
        public string? LastName { get; set; }
        [StringLength(100)]
        public string? MiddleName { get; set; }
        public string? Gender { get; set; }
        [StringLength(200)]
        public string? Address { get; set; }
        public string? CivilStatus { get; set; }
        public string? Occupation { get; set; }
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Invalid phone number.")]
        public string? MobileNumber { get; set; }
        public string? TeleNumber { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? Emergency_Name { get; set; }
        public string? Emergency_MobileNumber { get; set; }
        public bool HasPhilHealth { get; set; } = false;
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Invalid PhilHealth number.")]
        public string? PHIC_NO { get; set; }
        public DateOnly? Birthdate { get; set; }
        public string? BloodType { get; set; }
        public string? Religion { get; set; }


        // Foreign Key to Status table
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

        public string? StatusCode { get; set; }
        [ForeignKey("StatusCode")]
        public Status? Status { get; set; }

        public int? SpouseId { get; set; }
        [ForeignKey("SpouseId")]
        public Spouse? Spouse { get; set; }

    }
}
