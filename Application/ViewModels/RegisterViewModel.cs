using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Compare("Email", ErrorMessage = "Please Write Email Address")]
        public string ConfirmEmail { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password NOT MATCH!")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Text, ErrorMessage = "Invalid")]
        public string GivenName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Text, ErrorMessage = "Invalid")]
        public string FamilyName { get; set; } = string.Empty;

        [Required]
        public string Department { get; set; } = string.Empty;

        [Required]
        public string DepartmentNumber { get; set; } = string.Empty;

        public DateTime? MemberSince { get; set; } = DateTime.UtcNow;

        [Required]
        public string UserRole { get; set; } = string.Empty;
    }
}
