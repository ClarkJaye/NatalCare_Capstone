using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;

namespace NatalCare.Models.Entities
{
    public class Ward : BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? WardNo { get; set; }

    }
}
