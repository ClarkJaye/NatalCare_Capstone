using NatalCare.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;


namespace NatalCare.Models.Entities
{
    public class Status : BaseEntity
    {
        [Key]
        [Required]
        [StringLength(2)]
        public string? StatusCode { get; set; }

        [Required]
        public string? StatusName { get; set; }

        [Required]
        public DateTime Created_At { get; set; } = DateTime.Now;
    }

}