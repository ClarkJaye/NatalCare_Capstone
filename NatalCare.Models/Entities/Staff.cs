using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatalCare.Models.Entities
{
    public class Staff : BaseEntity
    {

        [Key]
        [Required]
        public int? Id { get; set; }

        [Required]
        public string? StaffName { get; set; }

        [Required]
        public int? RoleId { get; set; }
        [ForeignKey("RoleId")]
        public RoleStaff? RoleStaff { get; set; }

        public string? StatusCode { get; set; }
        [ForeignKey("StatusCode")]
        public Status? Status { get; set; }
    }
}
