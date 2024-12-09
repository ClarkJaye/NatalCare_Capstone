using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NatalCare.DataAccess.Entities;

namespace NatalCare.Models.Entities
{
    public class ProgressLabor : BaseEntity
    {   
        [Key]
        public int ID { get; set; }
        public DateOnly? Date { get; set; }
        public TimeOnly? Time { get; set; }
        [Column(TypeName = "decimal(4, 1)")]
        public decimal? Temperature { get; set; } 
        public string? BP { get; set; }
        public int? PulseRate { get; set; }
        public int? RespiratoryRate { get; set; }
        public string? UterineContractionInterval { get; set; }
        [Column(TypeName = "decimal(4, 1)")]
        public decimal? Cervicaldilation { get; set; }
        public string? BowStatus { get; set; }
        [Column(TypeName = "decimal(4, 1)")]
        public decimal? FetalHeartTones { get; set; }
        public string? FetalHeartToneChar { get; set; }
        public string? PresentingPart { get; set; }


        // Foreign Key
        [Required]
        public string? DeliveryID { get; set; }
        [ForeignKey("DeliveryID")]
        public Delivery? Delivery { get; set; }
       

    }
}
