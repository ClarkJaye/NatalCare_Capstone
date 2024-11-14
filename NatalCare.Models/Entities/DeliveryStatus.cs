using NatalCare.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatalCare.Models.Entities
{
    public class DeliveryStatus : BaseEntity
    {
        [Key]
        [Required]
        public int? Id { get; set; }

        [Required]
        public string? StatusName { get; set; }

    }
}
