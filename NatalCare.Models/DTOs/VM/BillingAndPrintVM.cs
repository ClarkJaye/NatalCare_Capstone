using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatalCare.Models.DTOs.VM
{
    public class BillingAndPrintVM
    {
        public PrintDTO? PrintDTO { get; set; }  

        public BillingDTO? BillingDTO { get; set; }

    }
}
