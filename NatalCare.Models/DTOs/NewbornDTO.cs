
using System.ComponentModel.DataAnnotations;

namespace NatalCare.Models.DTOs
{
    public class NewbornDTO
    {
        public string NewbornID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateOnly? DateofBirth { get; set; }
        public TimeOnly? TimeofBirth { get; set; }
        public string MotherID { get; set; }
        public string MotherFirstName { get; set; }
        public string MotherMiddleName { get; set; }
        public string MotherLastName { get; set; }

        public DateTime? Created_At { get; set; }
    }
}
