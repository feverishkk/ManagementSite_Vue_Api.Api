using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ApplicationUserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string GivenName { get; set; } = string.Empty;

        public string FamilyName { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public string DepartmentNumber { get; set; } = string.Empty;

        public DateTime? MemberSince { get; set; } = DateTime.UtcNow;

        public string Role { get; set; } = string.Empty;
    }
}
