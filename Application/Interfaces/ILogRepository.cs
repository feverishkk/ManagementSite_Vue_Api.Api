using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILogRepository
    {
        IList<Log> GetAllLog();
        IEnumerable<Log> LogForCRUD(string customerId, string managerId, string itemName, int itemNumber);
    }
}
