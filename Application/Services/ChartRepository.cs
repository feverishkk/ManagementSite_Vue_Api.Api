using Application.Interfaces;
using Application.ViewModels.Chart;
using CommonDatabase.DapperHelperContext.DapperHelper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ChartRepository : IChartRepository
    {
        private readonly CommonDbContext _commonDbContext;

        public ChartRepository(CommonDbContext commonDbContext)
        {
            _commonDbContext = commonDbContext;
        }

        public IList<GetCustomerGenderViewModel> GetCustomerGender()
        {
            using (var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<GetCustomerGenderViewModel>("usp_GetCustomerGender",
                                              commandType: System.Data.CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public IList<GetGuildPropertyViewModel> GetGuildProperty()
        {
            using (var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<GetGuildPropertyViewModel>("usp_GetGuildProperty",
                                              commandType: System.Data.CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public IList<GetMemberSinceViewModel> GetMemberSince()
        {
            using (var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<GetMemberSinceViewModel>("usp_GetMemberSince",
                                              commandType: System.Data.CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public IList<GetPreferPaymentViewModel> GetPreferPayment()
        {
            using (var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<GetPreferPaymentViewModel>("usp_GetPreferPayment",
                                              commandType: System.Data.CommandType.StoredProcedure);

                return result.ToList();
            }
        }
    }
}
