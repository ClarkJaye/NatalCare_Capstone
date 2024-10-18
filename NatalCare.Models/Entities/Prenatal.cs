using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;

namespace NatalCare.Models.Entities
{
    public class Prenatal : BaseEntity
    {
        [Key]
        [Required]
        public int PrenatalID { get; set; }

        public string? AOGWeek { get; set; }

        public string? Weight { get; set; }
        public string? BP { get; set; }
        public string? FH { get; set; }
        public string? FHT { get; set; }
        public string? DateVisit { get; set; }
        public string? NextVisit { get; set; }


        [ForeignKey("StatusCode")]
        public Status? Status { get; set; }

        [Required]
        public DateTime Created_At { get; set; } = DateTime.Now;
    }
}
