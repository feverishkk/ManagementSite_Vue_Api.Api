using Application.Interfaces;
using Application.ViewModels;
using CommonDatabase.DapperHelperContext.DapperHelper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ManagerRepository : IManagerRepository
    {

        private readonly ApplicationUserDbContext _dapperContext;
        public ManagerRepository(ApplicationUserDbContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        /// <summary>
        /// 모든 매니저를 다 들고온다.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ApplicationUserViewModel> GetAllManagers()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var result = connection.Query<ApplicationUserViewModel>("usp_GetAllManagers",
                                       commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// 매니저 삭제
        /// </summary>
        /// <param name="id"></param>
        public void DeleteManager(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ManagerId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute("usp_DeleteManager", parameter,
                                        commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// 특정 매니저의 정보를 가져온다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<ApplicationUserViewModel> GetManagerById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ManagerId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                var result = connection.Query<ApplicationUserViewModel>("usp_GetManagerById", parameter,
                                                       commandType: System.Data.CommandType.StoredProcedure);
                if (result is null)
                {
                    return null;
                }

                return result.ToList();
            }
        }

        /// <summary>
        /// 매니저 정보 수정
        /// 해야 함
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IList<UpdateManagerInfo> UpdateManagerInfo(UpdateManagerInfo model)
        {
            if(model.Id < 0 || model.Department is not null || model.DepartmentNumber is not null ||
               model.Department is not null)
            {

            }
            var parameters = new DynamicParameters();
            parameters.Add("@Id", model.Id);
            parameters.Add("@GivenName", model.GivenName);
            parameters.Add("@Department", model.Department);
            parameters.Add("@DepartmentNumber", model.DepartmentNumber);

            using (var connection = _dapperContext.CreateConnection())
            {
                var result = connection.Query<UpdateManagerInfo>("usp_UpdateManagerInfo", parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        /// <summary>
        /// 현재 매니저의 Role을 가지고 온다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IList<ApplicationUserViewModel> GetManagerRole(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var result = connection.Query<ApplicationUserViewModel>("usp_GetManagerRole", new {id = id},
                                              commandType: System.Data.CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        /// <summary>
        /// 매니저의 Role을 다른 Role로 업데이트해준다.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IList<UpdateManagerRoleViewModel> UpdateManagerRole(UpdateManagerRoleViewModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", model.Id);
            parameters.Add("@SelectedRole", model.SelectedRole);

            using (var connection = _dapperContext.CreateConnection())
            {
                var result = connection.Query<UpdateManagerRoleViewModel>("usp_UpdateManagerRole", parameters,
                                              commandType: System.Data.CommandType.StoredProcedure).ToList();

                return result;
            }
        }
    }
}
