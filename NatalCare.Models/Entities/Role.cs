using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatalCare.Models.Entities
{
    public class Role : IdentityRole
    {
        //// Applying validation directly to the existing property
        //[Required(ErrorMessage = "Role Name is required")]
        //public new string? Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        public DateTime? Created_At { get; set; } = DateTime.Now;

        [Column("Created_By")]
        public string? RoleCreatedBy { get; set; }

        [ForeignKey("RoleCreatedBy")]
        [ValidateNever]
        public User? CreatedBy { get; set; }

        public DateTime? Updated_At { get; set; }

        [Column("Updated_By")]
        public string? RoleUpdatedBy { get; set; }

        [ForeignKey("RoleUpdatedBy")]
        [ValidateNever]
        public User? UpdatedBy { get; set; }
    }
}
