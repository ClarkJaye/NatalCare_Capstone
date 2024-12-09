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

        public string? PlaceOfBirth { get; set; }
        public string? Address { get; set; }

        [Required]
        public DateOnly? DateofBirth { get; set; }

        [Required]
        public TimeOnly? TimeofBirth { get; set; }

        public string? DeliveryType { get; set; }
        public string? DeliveryPresentation { get; set; }

        // MEASUREMENTS
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

        public int? FatherID { get; set; }

        [ForeignKey("FatherID")]
        [ValidateNever]
        public Spouse? Father { get; set; }


        ////ASSISTED STAFF
        public int? MidwifeID { get; set; }
        [ForeignKey("MidwifeID")]
        [ValidateNever]
        public Staff? Midwife { get; set; }

        public int? PhysicianID { get; set; }
        [ForeignKey("PhysicianID")]
        [ValidateNever]
        public Staff? Physician { get; set; }

        public int? StaffID { get; set; }
        [ForeignKey("StaffID")]
        [ValidateNever]
        public Staff? AssisstedBy { get; set; }


    }
}
