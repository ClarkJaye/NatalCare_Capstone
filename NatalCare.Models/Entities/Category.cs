using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;

namespace NatalCare.Models.Entities
{
    public class Category : BaseEntity
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(20)]
        public string? CategoryName { get; set; }

        public string? StatusCode { get; set; }

        [ForeignKey("StatusCode")]
        public Status? Status { get; set; }

        [Required]
        public DateTime Created_At { get; set; } = DateTime.Now;
    }
}
