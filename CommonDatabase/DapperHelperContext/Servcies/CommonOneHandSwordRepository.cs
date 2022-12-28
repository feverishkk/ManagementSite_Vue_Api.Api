using CommonDatabase.DapperHelperContext.DapperHelper;
using CommonDatabase.DapperHelperContext.Interfaces;
using CommonDatabase.Models.TotalItems;
using CommonDatabase.Models.Weapons;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CommonDatabase.DapperHelperContext.Servcies
{
    public class CommonOneHandSwordRepository : ICommonOneHandSwordRepository
    {
        private readonly CommonDbContext _dapperContext;

        public CommonOneHandSwordRepository(CommonDbContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public IEnumerable<OneHandSword> GetAllOneHandSword()
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var result =  connection.QueryAsync<OneHandSword>("usp_GetAllOneHandSword", 
                                   commandType: CommandType.StoredProcedure).Result.ToList();

                return result.ToList();
            }
        }

        public OneHandSword CreateOneHandSword(OneHandSword oneHandSword)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OneHandSwordId", oneHandSword.OneHandSwordId);
            parameters.Add("@Image", oneHandSword.Image);
            parameters.Add("@Name", oneHandSword.Name);
            parameters.Add("@Damage1", oneHandSword.Damage1);
            parameters.Add("@Damage2", oneHandSword.Damage2);
            parameters.Add("@Class", oneHandSword.Class);
            parameters.Add("@Description", oneHandSword.Description);

            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute("usp_CreateOneHandSword", parameters,
                                    commandType: CommandType.StoredProcedure);

                return oneHandSword;
            }
        }

        public OneHandSword UpdateOneHandSword(OneHandSword oneHandSword)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OneHandSwordId", oneHandSword.OneHandSwordId);
            parameters.Add("@Image", oneHandSword.Image);
            parameters.Add("@Name", oneHandSword.Name);
            parameters.Add("@Damage1", oneHandSword.Damage1);
            parameters.Add("@Damage2", oneHandSword.Damage2);
            parameters.Add("@Class", oneHandSword.Class);
            parameters.Add("@Description", oneHandSword.Description);

            using(var connection = _dapperContext.CreateConnection())
            {
                connection.Execute("usp_UpdateOneHandSword", parameters, 
                                    commandType:CommandType.StoredProcedure);

                return oneHandSword;
            }
        }

        public int DeleteOneHandSword(int oneHandSwordId)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var result = connection.Execute("usp_DeleteOneHandSword", 
                                                new { OneHandSwordId = oneHandSwordId}, 
                                                commandType: CommandType.StoredProcedure);
                return oneHandSwordId;
            }
        }

        public IEnumerable<OneHandSword> SearchOneHandSwordByName(string oneHandSwordName)
        {
            var paramter = new DynamicParameters();
            paramter.Add("@Name", oneHandSwordName);

            using( var connection = _dapperContext.CreateConnection())
            {
                var result = connection.Query<OneHandSword>("usp_SearchOneHandSwordByName", paramter,
                                              commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
