using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class UpdateManagerInfo
    {
        public int Id { get; set; }
        public string GivenName { get; set; } = default!;
        public string Department { get; set; } = default!;
        public string DepartmentNumber { get; set; } = default!;
    }
}
