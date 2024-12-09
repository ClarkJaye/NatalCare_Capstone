using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatalCare.Models.DTOs
{
    public class ItemsDTO
    {

        [Required]
        [StringLength(20)]
        public string? ItemName { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public decimal? Amount { get; set; }

        [Required]
        public decimal? PhilHealthCovered { get; set; }

    }
}
