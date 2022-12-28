using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class UpdateUserInfoViewModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        public string GivenName { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;  
        public string DepartmentNumber { get; set; } = string.Empty;    

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
