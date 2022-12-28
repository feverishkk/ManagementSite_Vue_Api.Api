using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Log
    {
        public int Id { get; set; }
        /// <summary>
        /// 운영자
        /// </summary>
        public string ManagerUser { get; set; } = string.Empty;
        /// <summary>
        /// 고객
        /// </summary>
        public string CustomerUser { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public int ItemNumber { get; set; }
        public string FullPath { get; set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Method { get; set; } = string.Empty;
        public string RemoteIpAddress { get; set; } = string.Empty;
        public string StatusCode { get; set; } = string.Empty;
        public DateTime UpdateTime { get; set; }
    }
}
