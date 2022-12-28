using CommonDatabase.DapperHelperContext.DapperHelper;
using CommonDatabase.DapperHelperContext.Interfaces;
using CommonDatabase.Models.Accessories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.DapperHelperContext.Servcies
{
    public class CommonBeltRepository : ICommonBeltRepository
    {
        private readonly CommonDbContext _dapperContext;

        public CommonBeltRepository(CommonDbContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public IEnumerable<Belt> GetAllBelt()
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var result = connection.Query<Belt>("usp_GetAllBelt", 
                                        commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public Belt CreateBelt(Belt belt)
        {
            var paramters = new DynamicParameters();
            paramters.Add("@BeltId", belt.BeltId);
            paramters.Add("@Name", belt.Name);
            paramters.Add("@Class", belt.Class);
            paramters.Add("@AC", belt.AC);
            paramters.Add("@Image", belt.Image);
            paramters.Add("@Description", belt.Description);

            using(var connection = _dapperContext.CreateConnection())
            {
                connection.Execute("usp_CreateBelt", paramters,
                                   commandType: CommandType.StoredProcedure);

                return belt;
            }
        }
        public Belt UpdateBelt(Belt belt)
        {
            var paramters = new DynamicParameters();
            paramters.Add("@BeltId", belt.BeltId);
            paramters.Add("@Name", belt.Name);
            paramters.Add("@Class", belt.Class);
            paramters.Add("@AC", belt.AC);
            paramters.Add("@Image", belt.Image);
            paramters.Add("@Description", belt.Description);

            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute("usp_UpdateBelt", paramters,
                                   commandType: CommandType.StoredProcedure);

                return belt;
            }
        }
        public int DeleteBelt(int beltId)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var result = connection.Execute("usp_UpdateBelt", new { BeltId = beltId },
                                   commandType: CommandType.StoredProcedure);

                return result;
            }
        }
        public IEnumerable<Belt> SearchBeltByName(string BeltName)
        {
            var paramter = new DynamicParameters();
            paramter.Add("@Name", BeltName);

            using (var connection = _dapperContext.CreateConnection())
            {
                var result = connection.Query<Belt>("usp_SearchBeltByName", paramter,
                                              commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
