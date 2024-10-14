using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Identity;
using NatalCare.DataAccess.Entities;

namespace NatalCare.Models.Entities
{
    public class Role_Access : BaseEntity
    {
        [ForeignKey("Roles")]
        public string? RoleId { get; set; }
        [ValidateNever]
        public Role? Role { get; set; }

        public int? ModuleId { get; set; }
        [ValidateNever]
        [ForeignKey("ModuleId")]
        public Modules? Module { get; set; }


        [Required]
        [StringLength(1)]
        [DisplayName("OPEN ACCESS")]
        public string? OpenAccess { get; set; }

        [Required]
        public DateTime Created_At { get; set; } = DateTime.Now;
    }
}
