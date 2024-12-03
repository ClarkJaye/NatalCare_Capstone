﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;

namespace NatalCare.Models.Entities
{
    public class MaternalMonitoring : BaseEntity
    {   
        [Key]
        public int ID { get; set; }
        public DateOnly? BabyDateDelivered{ get; set; }
        public TimeOnly? BabyTimeDelivered{ get; set; }
        public string? Apgar { get; set; }
        public string? BabySex { get; set; }
        public string? BabyWeight { get; set; }
        public TimeOnly? PlacentaTimeDelevered { get; set; }
        public string? PlacentaStatus { get; set; }
        public string? ServiceProviderName { get; set; }
        public string? Notes { get; set; }


        // Foreign Key
        [Required]
        public string? CaseNo { get; set; }
        [ForeignKey("CaseNo")]
        public Delivery? Delivery { get; set; }

        [Required]
        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]
        [ValidateNever]
        public Patients? Patient { get; set; }

        public DateTime? Created_At { get; set; }
        [Column("Created_By")]
        public string? MDCreatedBy { get; set; }
        [ForeignKey("MDCreatedBy")]
        [ValidateNever]
        public User? CreatedBy { get; set; }

        public DateTime? Updated_At { get; set; }
        [Column("Updated_By")]
        public string? MDUpdatedBy { get; set; }
        [ForeignKey("MDUpdatedBy")]
        [ValidateNever]
        public User? UpdatedBy { get; set; }

        public string? StatusCode { get; set; }
        [ForeignKey("StatusCode")]
        [ValidateNever]
        public Status? Status { get; set; }

    }
}
