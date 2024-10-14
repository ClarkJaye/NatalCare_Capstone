using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using NatalCare.Models.Entities;

namespace NatalCare.Models.ViewModel
{
    public class UserRolesViewModel
    {
        public User? User { get; set; }
        public List<string>? Roles { get; set; }
    }

}
