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
    public class EarRingRepository : IEarRingRepository
    {
        private readonly CommonDbContext _commonDbContext;

        public EarRingRepository(CommonDbContext commonDbContext)
        {
            _commonDbContext = commonDbContext;
        }
        public IList<EarRing> GetAll()
        {
            using (var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<EarRing>("usp_GetAllEarRing",
                                                commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public Task<EarRing> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
