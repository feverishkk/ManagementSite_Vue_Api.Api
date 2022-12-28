using Application.Interfaces;
using Application.ViewModels;
using CommonDatabase.DapperHelperContext.DapperHelper;
using Dapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LogRepository : ILogRepository
    {
        private readonly ApplicationUserDbContext _applicationUserDbContext;
        private readonly CommonDbContext _commonDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogRepository(ApplicationUserDbContext applicationUserDbContext, IHttpContextAccessor httpContextAccessor,
                             CommonDbContext commonDbContext)
        {
            _applicationUserDbContext = applicationUserDbContext;
            _commonDbContext = commonDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public IList<Log> GetAllLog()
        {
            using(var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<Log>("usp_GetAllLog", 
                                        commandType: System.Data.CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        
        public IEnumerable<Log> LogForCRUD(string customerId, string managerId, string itemName, 
                                           int itemNumber)
        {
            var contextRequest = _httpContextAccessor.HttpContext.Request;
            var ManagerUser = managerId.ToString();
            var CustomerUser = customerId.ToString();
            var ItemName = itemName.ToString();
            int ItemNumber = (int)(long)itemNumber;
            var FullPath = contextRequest.Path.ToString();
            var Host = contextRequest.Host.ToString();
            int Port = (int)contextRequest.Host.Port;
            var Method = contextRequest.Method.ToString();
            var RemoteIpAddr = contextRequest.HttpContext.Connection.RemoteIpAddress.ToString();
            var StatusCode = contextRequest.HttpContext.Response.StatusCode.ToString();
            var DateTime = System.DateTime.Now;

            var parameters = new DynamicParameters();
            parameters.Add("@ManagerUser", ManagerUser);
            parameters.Add("@CustomerUser", CustomerUser);
            parameters.Add("@ItemName", ItemName);
            parameters.Add("@ItemNumber", ItemNumber);
            parameters.Add("@FullPath", FullPath);
            parameters.Add("@Host", Host);
            parameters.Add("@Port", Port);
            parameters.Add("@Method", Method);
            parameters.Add("@RemoteIpAddress", RemoteIpAddr);
            parameters.Add("@StatusCode", StatusCode);
            parameters.Add("@DateTime", DateTime);

            using (var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<Log>("usp_LogForCRUD", parameters,
                                   commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }


    }
}
