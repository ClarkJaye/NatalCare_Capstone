using NatalCare.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace NatalCare.Models.Entities
{
    public class Items : BaseEntity
    {
        [Key]
        public int ItemID { get; set; }
        [StringLength(100)]
        public string? ItemName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }

        //public DateTime? Created_At { get; set; }
        //[Column("Created_By")]
        //public string? ItemCreatedBy { get; set; }
        //[ForeignKey("ItemCreatedBy ")]
        //[ValidateNever]
        //public User? CreatedBy { get; set; }

        //public DateTime? Updated_At { get; set; }
        //[Column("Updated_By")]
        //public string? ItemUpdatedBy { get; set; }
        //[ForeignKey("ItemUpdatedBy ")]
        //[ValidateNever]
        //public User? UpdatedBy { get; set; }
    }
}
