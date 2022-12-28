using Application.Interfaces;
using Application.ViewModels;
using CommonDatabase.DapperHelperContext.DapperHelper;
using Dapper;
using Shared;

namespace Application.Services
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationUserDbContext _dapperContext;

        public ApplicationUserRepository(ApplicationUserDbContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public IEnumerable<LoginViewModel> Login(LoginViewModel model)
        {
            var DecrptPassWord = HashExtensions.HashString(model.Password);

            var parameters = new DynamicParameters();
            parameters.Add("@Email", model.Email);
            parameters.Add("@Password", DecrptPassWord);

            using (var connection = _dapperContext.CreateConnection())
            {
                var result = connection.Query<LoginViewModel>("usp_Login", parameters,
                                   commandType: System.Data.CommandType.StoredProcedure);

                return result;
            }
        }

        public IEnumerable<ApplicationUserViewModel> Register(RegisterViewModel model)
        {
            if ((model.Password != model.ConfirmPassword) || (model.Email != model.ConfirmEmail))
            {
                throw new InvalidDataException();
            }

            var beforeHashingPassWord = model.Password;
            var hashedPassWord = HashExtensions.HashString(beforeHashingPassWord);

            var parameters = new DynamicParameters();
            parameters.Add("@Email", model.Email);
            parameters.Add("@Password", hashedPassWord);
            parameters.Add("@GivenName", model.GivenName);
            parameters.Add("@FamilyName", model.FamilyName);
            parameters.Add("@Department", model.Department);
            parameters.Add("@DepartmentNumber", model.DepartmentNumber);
            parameters.Add("@MemberSince", model.MemberSince);
            parameters.Add("@Role", model.UserRole);

            using (var connection = _dapperContext.CreateConnection())
            {
                var result = connection.Query<ApplicationUserViewModel>("usp_Register", parameters,
                                                       commandType: System.Data.CommandType.StoredProcedure);

                return result;
            }
        }

        public bool IsExistUser(string email)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var result = connection.Execute("usp_IsExistUser", new { Email = email },
                                       commandType: System.Data.CommandType.StoredProcedure);
                if (result is 0)
                    return false;
                else
                    return true;
            }
        }

        public IList<UpdateUserInfoViewModel> UpdateUserInfomation(UpdateUserInfoViewModel model)
        {
            if(string.IsNullOrEmpty(model.Email) || model.Password != model.ConfirmPassword)
            {
                throw new ArgumentException();
            }

            var hashingPassWord = HashExtensions.HashString(model.Password);

            var parameters = new DynamicParameters();
            parameters.Add("@Email", model.Email);
            parameters.Add("@GivenName", model.GivenName);
            parameters.Add("@Department", model.Department);
            parameters.Add("@DepartmentNumber", model.DepartmentNumber);
            parameters.Add("@Password", hashingPassWord);

            using(var connection = _dapperContext.CreateConnection())
            {
                var result = connection.Query<UpdateUserInfoViewModel>("usp_UpdateUserInfo", parameters,
                                               commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

    }
}
