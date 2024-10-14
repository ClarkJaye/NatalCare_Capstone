using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NatalCare.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NatalCare.DataAccess.Entities;

public class Newborn : BaseEntity
{
    [Key]
    [Required]
    public string? NewbornID { get; set; }

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    [Required]
    public string? Gender { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Circumference { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Head { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Chest { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Length { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Temp { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Weight { get; set; }

    [Range(0, 10)]
    public int? APGAR { get; set; }

    public string? Medication { get; set; }

    public bool? IsActive { get; set; }

    [Required]
    public DateOnly? DateofBirth { get; set; }

    [Required]
    public TimeOnly? TimeofBirth { get; set; }

    public DateTime? Created_At { get; set; }

    public DateTime? Updated_At { get; set; }

    // Foreign Key
    public string? StatusCode { get; set; }

    [ForeignKey("StatusCode")]
    public Status? Status { get; set; }

    public string? MotherID { get; set; }

    [ForeignKey("MotherID")]
    [ValidateNever]
    public Patients? Patient { get; set; }
}
