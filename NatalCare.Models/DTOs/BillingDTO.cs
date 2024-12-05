using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatalCare.Models.DTOs
{
    public class BillingDTO
    {

        public int? paymentID { get; set; }

        [Required]
        [StringLength(20)]
        public string? PatientName { get; set; }

        [Required]
        [StringLength(20)]
        public string? StaffName { get; set; }

        [Required]
        public DateOnly? BillDate { get; set; }

        [Required]
        public DateOnly? DueDate { get; set; }

        [Required]
        public List<ItemsDTO>? Items { get; set; } = new List<ItemsDTO>();

        [Required]
        public List<ServicesDTO>? Services { get; set; } = new List<ServicesDTO>();

        public string? Notes { get; set; }

        [Required]
        public decimal? SubTotal { get; set; }


        [Required]
        public decimal? PhilHeathTotal { get; set; }

        [Required]
        public decimal? Discount { get; set; }

        [Required]
        public decimal? TotalAmount { get; set; }

    }
}
