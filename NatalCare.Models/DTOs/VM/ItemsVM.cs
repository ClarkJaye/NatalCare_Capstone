using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatalCare.Models.DTOs.VM
{
    public class ItemsVM
    {
        public string? ItemName { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public decimal? PhilHealthCovered { get; set; }

        public decimal? Total { get; set; }

    }
}
