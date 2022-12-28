using Application.Interfaces;
using Application.ViewModels;
using Application.ViewModels.Chart;
using CommonDatabase.DapperHelperContext.DapperHelper;
using CommonDatabase.Models.Customers;
using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CommonDbContext _commonDbContext;

        public CustomerRepository(CommonDbContext commonDbContext)
        {
            _commonDbContext = commonDbContext;
        }

        public IEnumerable<CustomerInfomation> GetAllCustomers()
        {
            using (var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<CustomerInfomation>("usp_GetAllCustomers",
                                                commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// 특정 유저를 id를통해 가져온다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<CustomerInfomation> GetCustomerById(string id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@id", id);

            using (var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<CustomerInfomation>("usp_GetCustomerById", parameter,
                                                   commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        /// <summary>
        /// 유저가 장착하고 있는 장비들의 목록을 가져온다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CustomerEquipment> GetCustomerEquipment(string id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@id", id);

            using (var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<CustomerEquipment>("usp_GetCustomerEquipment", parameter,
                                              commandType: System.Data.CommandType.StoredProcedure)
                                              .ToList();

                return result;
            }

        }

        /// <summary>
        /// 유저의 인게임에서의 정보 현황
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomersInGameInfo> GetCustomersInGameInfo(string id)
        {
            using (var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<CustomersInGameInfo>("usp_GetCustomerInGameInfo", new { id = id },
                                                commandType: System.Data.CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        /// <summary>
        /// 유저의 장비들을 바꿔줄 수 있다.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public IList<CustomerEquipment> UpdateCustomerEquipment(UpdateCustomerEquipmentViewModel model)
        {
            string query = $"UPDATE CustomerEquipment "+
                           $"SET {model.ItemName}Id = {model.SelectedItem} "+
                           $"WHERE Id = '{model.CustomerId}'";

            using (var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<CustomerEquipment>(query, model);
                
                return (IList<CustomerEquipment>)result;
            }
        }

        
    }
}
