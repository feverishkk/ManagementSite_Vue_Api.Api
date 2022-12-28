using Application.Interfaces.GetItems;
using CommonDatabase.DapperHelperContext.DapperHelper;
using CommonDatabase.Models.Accessories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.GetItems
{
    public class BeltRepository : IBeltRepository
    {
        private readonly CommonDbContext _commonDbContext;

        public BeltRepository(CommonDbContext commonDbContext)
        {
            _commonDbContext = commonDbContext;
        }
        public IList<Belt> GetAll()
        {
            using (var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<Belt>("usp_GetAllBelt",
                                                commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public Task<Belt> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
