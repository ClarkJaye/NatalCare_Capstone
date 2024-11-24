using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.DataAccess.Entities;

namespace NatalCare.Models.Entities
{
    public class Obstetrical : BaseEntity
    {   
        [Key]
        public int ID { get; set; }
        public string? FirstDayOfLastMenstrualCycle { get; set; }
        public string? PriorMensesDate { get; set; }
        public string? FrequencyOfCycleEvery { get; set; }
        public bool DaysMensesMonthly { get; set; } = false;
        public string? AgesOfFirstMenses { get; set; }
        public bool BirthControlTheOfPregnancy { get; set; } = false;
        public string? DateOfPositivePregnancyTest { get; set; }
        public string? PregnancyTestDoneBy { get; set; }

        public int? TotalNoOfPreg { get; set; }
        public int? NoOf_FullTerm { get; set; }
        public int? NoOf_Premature { get; set; }
        public int? NoOfAbortions { get; set; }
        public int? NoOfMiscarriages { get; set; }
        public int? NoOfD_CWithCarriagesPregnancy { get; set; }


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
        public string? ObsCreatedBy { get; set; }
        [ForeignKey("ObsCreatedBy")]
        [ValidateNever]
        public User? CreatedBy { get; set; }

        public DateTime? Updated_At { get; set; }
        [Column("Updated_By")]
        public string? ObsUpdatedBy { get; set; }
        [ForeignKey("ObsUpdatedBy")]
        [ValidateNever]
        public User? UpdatedBy { get; set; }

        public string? StatusCode { get; set; }
        [ForeignKey("StatusCode")]
        [ValidateNever]
        public Status? Status { get; set; }

    }
}
