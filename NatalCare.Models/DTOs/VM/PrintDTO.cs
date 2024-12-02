using NatalCare.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatalCare.Models.DTOs.VM
{
    public class PrintDTO
    {
        public Payments? Payments { get; set; }

        public List<ItemPayments>? Items { get; set; } // Changed to ItemPayments to match the repository type

        public List<ServicesPayment>? Services { get; set; } // Corrected property name to ServicesPayment
    }
}
