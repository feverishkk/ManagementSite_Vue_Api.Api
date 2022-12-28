using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.Customers
{
    public class CustomersInGameInfo
    {
        [Key]
        public int UserId { get; set; }
        public string ID { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public UserClass UserClass { get; set; }
        public string GuildName { get; set; } = string.Empty;
        
    }
}
