using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NatalCare.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NatalCare.Models.Entities
{
    public class FamilyPlanning : BaseEntity
    {
        [Key]
        [Required]
        public string? CaseNo { get; set; }
        public int? NoOfLivingChild { get; set; }
        public bool? PlantToHaveChild { get; set; }
        public double? AverageMonthlyIncome { get; set; }

        public string? MethodType { get; set; }

        //Medical History
        public bool? HaveHeadaches_Migraine { get; set; }
        public bool? HasStroke_HeartAttack { get; set; }
        public bool? HasGumBleeding { get; set; }
        public bool? HasBeastCancer { get; set; }
        public bool? HasSeverChestPain { get; set; }
        public bool? HasCough14days { get; set; }
        public bool? HasJaundice { get; set; }
        public bool? HasViginalBleeding { get; set; }
        public bool? HasViginalDischarge { get; set; }
        public bool? IsSmoker { get; set; }
        public bool? IntakeAntiTB { get; set; }
        public bool? WithDisability { get; set; }

        //OBSTETRICAL HISTORY
        public int? NumberOfPregnancies { get; set; }
        public int? Para { get; set; }
        public int? Abortion { get; set; }
        public DateOnly? LastMenstrualPeriod { get; set; }
        public DateOnly? LastDelivery{ get; set; }
        public string? MenstrualFlow{ get; set; }
        public bool? HasDysmenorhea{ get; set; }
        public bool? HasHydatidiformMole{ get; set; }
        public bool? HasHistoryEctopicPregnancy { get; set; }

        // RISK FOR VIOLENCE AGAINST WOMEN
        public bool? UnpleasntRelationship { get; set; }
        public bool? NotApproveVisitClinic { get; set; }
        public string? HistoryOfDomesticViolence  { get; set; }


        // Physical Examnation
        public string? Weight { get; set; }
        public string? Height { get; set; }
        public string? BP { get; set; }
        public string? PulseRate { get; set; }

        public string? Skin { get; set; }
        public string? Extemeities { get; set; }
        public string? Conjunctiva { get; set; }
        public string? Neck { get; set; }
        public string? Breast { get; set; }
        public string? Abdomen { get; set; }
        public string? PelvicExamination { get; set; }





        // Foreign Key
        [Required]
        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]
        [ValidateNever]
        public Patients? Patient { get; set; }

        public DateTime? Created_At { get; set; }
        [Column("Created_By")]
        public string? FPCreatedBy { get; set; }
        [ForeignKey("FPCreatedBy")]
        [ValidateNever]
        public User? CreatedBy { get; set; }

        public DateTime? Updated_At { get; set; }
        [Column("Updated_By")]
        public string? FPUpdatedBy { get; set; }
        [ForeignKey("FPUpdatedBy")]
        [ValidateNever]
        public User? UpdatedBy { get; set; }

        public string? StatusCode { get; set; }
        [ForeignKey("StatusCode")]
        [ValidateNever]
        public Status? Status { get; set; }
    }
}
