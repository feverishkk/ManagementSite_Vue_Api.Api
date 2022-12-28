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
    public class ArmorRepository : IArmorRepository
    {
        private readonly CommonDbContext _commonDbContext;

        public ArmorRepository(CommonDbContext commonDbContext)
        {
            _commonDbContext = commonDbContext;
        }
        public IList<Armor> GetAll()
        {
            using(var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<Armor>("usp_GetAllArmor", 
                                    commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public Task<Armor> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
