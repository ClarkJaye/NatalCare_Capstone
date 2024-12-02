using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatalCare.Models.DTOs.VM
{
    public class PrintVM
    {
        public int? InvoiceNumber { get; set; }

        public DateOnly? BillDate { get; set; }

        public DateOnly? DueDate { get; set; }

        public string? PatientName { get; set; }

        public string? MobileNumber { get; set; }

        public string? Address { get; set; }

        public List<ItemsVM>? Items { get; set; }

        public List<ServicesVM>? Services { get; set; }

        public decimal? Balance { get; set; }

        public string? InVoiceGeneratedBy{ get; set; }

        public string? Notes{ get; set; }

        public decimal? SubTotal { get; set; }

        public decimal? Discount { get; set; }

        public decimal? PhilHealthTotal { get; set; }

        public decimal? TotalPayment { get; set; }

    }
}
