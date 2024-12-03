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
        public DateTime? PriorMensesDate { get; set; }
        public string? FrequencyOfCycleEvery { get; set; }
        public bool DaysMensesMonthly { get; set; } = false;
        public int? AgesOfFirstMenses { get; set; }
        public bool BirthControlTheOfPregnancy { get; set; } = false;
        public DateTime? DateOfPositivePregnancyTest { get; set; }
        public string? PregnancyTestDoneBy { get; set; }

        //PAST PREGNANCY
        public int? TotalNoOfPreg { get; set; }
        public int? NoOf_FullTerm { get; set; }
        public int? NoOf_Premature { get; set; }
        public int? NoOfAbortions { get; set; }
        public int? NoOfMiscarriages { get; set; }
        public int? NoOfD_CWithCarriagesPregnancy { get; set; }
        public int? NoOfPregnancy_TubalPregnancy { get; set; }
        public int? NoOfMultipleBirths { get; set; }
        public int? NoOfLiving { get; set; }

        public string? PregnancyMonthYear { get; set; }
        public int? NoOfWeeks { get; set; }
        public string? LaborLengthHours { get; set; }
        public string? BirthWeigth { get; set; }
        public string? BirthSex { get; set; }
        public string? Vaginal_CS{ get; set; }
        public string? AnesthesiaType { get; set; }
        public string? PlaceOfDelivery { get; set; }
        public bool? PretermLabor { get; set; }
        public string? ComplicationsOrComments{ get; set; }


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
