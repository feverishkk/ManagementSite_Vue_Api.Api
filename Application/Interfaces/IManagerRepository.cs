using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IManagerRepository
    {
        IEnumerable<ApplicationUserViewModel> GetAllManagers();
        IList<ApplicationUserViewModel> GetManagerById(int id);
        IList<ApplicationUserViewModel> GetManagerRole(int id);
        IList<UpdateManagerRoleViewModel> UpdateManagerRole(UpdateManagerRoleViewModel model);
        IList<UpdateManagerInfo> UpdateManagerInfo(UpdateManagerInfo model);
        void DeleteManager(int id);
    }
}
