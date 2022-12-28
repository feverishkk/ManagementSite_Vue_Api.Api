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
    public class GuardRepository : IGuardRepository
    {
        private readonly CommonDbContext _commonDbContext;

        public GuardRepository(CommonDbContext commonDbContext)
        {
            _commonDbContext = commonDbContext;
        }
        public IList<Guard> GetAll()
        {
            using (var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<Guard>("usp_GetAllGuard",
                                                commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public Task<Guard> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
