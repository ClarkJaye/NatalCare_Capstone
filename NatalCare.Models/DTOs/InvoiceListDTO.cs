using NatalCare.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatalCare.Models.DTOs
{
    public class InvoiceListDTO
    {
       public List<Payments>? Payments { get; set; }

       public List<PatientPayments>? PatientPayments { get; set; }

    }
}
