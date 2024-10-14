using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatalCare.Models.Entities
{
    public class Patients : BaseEntity
    {
        [Key]
        [Required]
        public string? PatientID { get; set; }

        //[Required]
        [StringLength(100)]
        public string? FirstName { get; set; }

        //[Required]
        [StringLength(100)]
        public string? LastName { get; set; }

        //[Required]
        [StringLength(100)]
        public string? MiddleName { get; set; }

        //[Required]
        public string? Gender { get; set; }

        //[Required]
        [StringLength(200)]
        public string? Address { get; set; }

        public string? CivilStatus { get; set; }
        public string? Occupation { get; set; }

        [StringLength(50)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number.")]
        public string? ContactNumber { get; set; }
        //[Required]
        public string? PlaceOfBirth { get; set; }
        public string? Emergency_Name { get; set; }
        public string? Emergency_Contact { get; set; }
        public bool? HasPhilHealth { get; set; }

        [RegularExpression(@"^\d{12}$", ErrorMessage = "Invalid PhilHealth number.")]
        public string? PHIC_NO { get; set; }

        //[Required]
        public DateOnly? Birthdate { get; set; }

        //[Required]
        public DateTime? Created_At { get; set; }

        [Column("Created_By")]
        public string? PatientCreatedBy { get; set; }

        [ForeignKey("PatientCreatedBy")]
        [ValidateNever]
        public User? CreatedBy { get; set; }

        public DateTime? Updated_At { get; set; }

        // Foreign Key to Status table
        public string? StatusCode { get; set; }

        [ForeignKey("StatusCode")]
        public Status? Status { get; set; }
    }
}
