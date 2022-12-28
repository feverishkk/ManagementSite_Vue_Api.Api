using Application.ViewModels;
using Application.ViewModels.Chart;
using CommonDatabase.Models.Customers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerInfomation> GetAllCustomers();
        IList<CustomerInfomation> GetCustomerById(string id);
        List<CustomerEquipment> GetCustomerEquipment(string id);
        IEnumerable<CustomersInGameInfo> GetCustomersInGameInfo(string id);
        IList<CustomerEquipment> UpdateCustomerEquipment(UpdateCustomerEquipmentViewModel? model = null);
    }
}
