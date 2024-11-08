using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatalCare.Models.Entities
{
    public class Spouse : BaseEntity
    {
        [Key]
        public int SpouseId { get; set; }
        [StringLength(100)]
        public string? FirstName { get; set; }
        [StringLength(100)]
        public string? LastName { get; set; }
        [StringLength(100)]
        public string? MiddleName { get; set; }
        public string? Gender { get; set; }
        [StringLength(200)]
        public string? Address { get; set; }
        public string? Occupation { get; set; }
        public DateOnly? Birthdate { get; set; }

    }
}
