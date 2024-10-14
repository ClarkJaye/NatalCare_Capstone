using NatalCare.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace NatalCare.Models.DTOs
{
    public class UserDetailDTO
    {
        public string? Id { get; set; }

        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public Role? Role { get; set; }
        public Status? Status { get; set; }
        public string? Gender { get; set; }
        public DateOnly? Birthdate { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
    }
}
