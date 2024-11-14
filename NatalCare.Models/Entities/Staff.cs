using NatalCare.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatalCare.Models.Entities
{
    public class Staff : BaseEntity
    {

        [Key]
        public int? Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public int? RoleId { get; set; }
        [ForeignKey("RoleId")]
        public RoleStaff? RoleStaff { get; set; }
    }
}
