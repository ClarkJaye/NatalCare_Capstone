using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatalCare.Models.Entities
{
    public class Modules : BaseEntity
    {
        [Key]
        [Required]
        public int ModuleId { get; set; }

        [Required]
        public string? ModuleTitle { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category? Category { get; set; }

        public string? StatusCode { get; set; }
        [ForeignKey("StatusCode")]
        public Status? Status { get; set; }

        [Required]
        public DateTime Created_At { get; set; } = DateTime.Now;
    }
}
