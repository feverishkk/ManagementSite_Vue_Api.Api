using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.Customers
{
    public class CustomerInfomation
    {
        public int UserId { get; set; }
        public string ID { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateTime MemberSince { get; set; }
        public int Gender { get; set; }
        public int IsActive { get; set; }
        public int IsEmailConfirmed { get; set; }
        public string MobileNumber { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PreferPayment { get; set; } = string.Empty;
        public int PaidCash { get; set; } 
    }
}
