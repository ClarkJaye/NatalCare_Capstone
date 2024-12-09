using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;

namespace NatalCare.Models.Entities
{
    public class Bed : BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? BedNo { get; set; }

        [Required]
        public bool IsUsed { get; set; } = false;

        public int? WardID { get; set; }
        [ForeignKey("WardID")]
        [ValidateNever]
        public Ward? Wards { get; set; }

        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]
        [ValidateNever]
        public Patients? Patient { get; set; }

    }
}
