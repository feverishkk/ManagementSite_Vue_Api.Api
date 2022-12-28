using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class UpdateCustomerEquipmentViewModel
    {
        /// <summary>
        /// 고객의 Id
        /// </summary>
        public string CustomerId { get; set; } = string.Empty;

        /// <summary>
        /// 아이템의 종류를 받는다.
        /// ex) 무기, 벨트, 장갑, 망토 이러한 것들..
        /// </summary>
        public string ItemName { get; set; } = string.Empty;

        /// <summary>
        /// 운영자가 선택한 아이템의 번호
        /// </summary>
        public int SelectedItem { get; set; }

        /// <summary>
        /// 운영자의 Id
        /// </summary>
        public string ManagerId { get; set; } = string.Empty;
    }
}
