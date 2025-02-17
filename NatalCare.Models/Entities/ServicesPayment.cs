﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;

namespace NatalCare.Models.Entities
{
    public class ServicesPayment : BaseEntity
    {
        public int? ServiceID { get; set; }
        [ForeignKey("ServiceID")]
        [ValidateNever]
        public Servicesss? Services { get; set; }

        public int? PaymentID { get; set; }
        [ValidateNever]
        [ForeignKey("PaymentID")]
        public Payments? Payments { get; set; }

        public int? Quantity { get; set; }

        public decimal? PhilhealthCovered { get; set; }
    }
}
