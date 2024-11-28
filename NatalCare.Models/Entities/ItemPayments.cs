using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;

namespace NatalCare.Models.Entities
{
    public class ItemPayments : BaseEntity
    {
        public int? ItemID { get; set; }
        [ForeignKey("ItemID")]
        [ValidateNever]
        public Items? Items { get; set; }

        public int? PaymentID { get; set; }
        [ValidateNever]
        [ForeignKey("PaymentID")]
        public Modules? Module { get; set; }

        public int? Quantity { get; set; }

        public decimal? PhilHealthCovered { get; set; }

    }
}
