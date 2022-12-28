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
    public class RingTwoRepository : IRingTwoRepository
    {
        private readonly CommonDbContext _commonDbContext;

        public RingTwoRepository(CommonDbContext commonDbContext)
        {
            _commonDbContext = commonDbContext;
        }
        public IList<Ring2> GetAll()
        {
            using (var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<Ring2>("usp_GetAllRingTwo",
                                                commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public Task<Ring2> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
