using Application.ViewModels;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IApplicationUserRepository
    {
        IEnumerable<LoginViewModel> Login(LoginViewModel model);
        IEnumerable<ApplicationUserViewModel> Register(RegisterViewModel model);
        bool IsExistUser(string email);
        IList<UpdateUserInfoViewModel> UpdateUserInfomation(UpdateUserInfoViewModel model);
    }
}
