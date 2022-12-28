using Application.Interfaces.GetItems;
using CommonDatabase.DapperHelperContext.DapperHelper;
using CommonDatabase.Models.Equipment;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.GetItems
{
    public class CapeRepository : ICapeRepository
    {
        private readonly CommonDbContext _commonDbContext;

        public CapeRepository(CommonDbContext commonDbContext)
        {
            _commonDbContext = commonDbContext;
        }
        public IList<Cape> GetAll()
        {
            using (var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<Cape>("usp_GetAllCape",
                                                commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public Task<Cape> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
